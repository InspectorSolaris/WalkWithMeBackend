using Itinero;
using Itinero.IO.Osm;
using Itinero.LocalGeo;
using Itinero.Osm.Vehicles;
using OsmSharp;
using OsmSharp.API;
using OsmSharp.Streams;
using OsmSharp.Streams.Filters;
using OsmSharp.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WalkWithMeBackend.Extensions.Osm;
using WalkWithMeBackend.Model;

namespace WalkWithMeBackend.Services
{
    public class OsmService
    {
        private Router Router { get; }

        private OsmStreamSource OsmGeos { get; }

        private string DbFolder { get; } = @"Data\Osm";

        private string DbRouterName { get; } = "Pedestrian.routerdb";

        private string DbOsmName { get; } = "siberian-fed-district-latest.osm.pbf";

        public OsmService()
        {
            var routerFileStream = File.OpenRead(Path.Combine(DbFolder, DbRouterName));
            var osmFileStream = File.OpenRead(Path.Combine(DbFolder, DbOsmName));

            Router = CreateRouter(routerFileStream);
            OsmGeos = CreateOsmGeos(osmFileStream);
        }

        private Router CreateRouter(
            FileStream fileStream)
        {
            var routerDb = RouterDb.Deserialize(fileStream);

            return new Router(routerDb);
        }

        private OsmStreamSource CreateOsmGeos(
            FileStream fileStream)
        {
            return new PBFOsmStreamSource(fileStream);
        }

        private Node FindNode(
            long id)
        {
            return (Node)OsmGeos.First(x => x is Node n && n.Id == id);
        }

        private IEnumerable<(Coordinate Coordinate, IEnumerable<Tag> Tags)> SelectNodePOIs(
            IEnumerable<Node> nodes,
            IDictionary<string, IEnumerable<string>> tags)
        {
            nodes = nodes.Where(n => n.Tags.Any(t => t.InTags(tags)));

            var result = new List<(Coordinate Coordinate, IEnumerable<Tag> Tags)>();
            foreach (var node in nodes)
            {
                var latitude = (float)node.Latitude;
                var longitude = (float)node.Longitude;
                var resultTags = node.Tags.Where(t => t.InTags(tags));

                result.Add((new Coordinate(latitude, longitude), resultTags));
            }

            return result;
        }

        private IEnumerable<(Coordinate Coordinate, IEnumerable<Tag> Tags)> SelectWayPOIs(
            IEnumerable<Way> ways,
            IDictionary<string, IEnumerable<string>> tags)
        {
            ways = ways.Where(w => w.Tags.Any(t => t.InTags(tags)));

            var result = new List<(Coordinate Coordinate, IEnumerable<Tag> Tags)>();
            foreach (var way in ways)
            {
                var coordinates = way.Nodes
                    .Select(id => FindNode(id))
                    .Select(n => (Latitude: (float)n.Latitude / way.Nodes.Length, Longitude: (float)n.Longitude / way.Nodes.Length));

                var latitude = coordinates.Sum(c => c.Latitude);
                var longitude = coordinates.Sum(c => c.Longitude);
                var resultTags = way.Tags.Where(t => t.InTags(tags));

                result.Add((new Coordinate(latitude, longitude), resultTags));
            }

            return result;
        }

        public (IEnumerable<Coordinate> Path, double Distance) BuildRoute(
            Coordinate begin,
            Coordinate end)
        {
            var route = Router.Calculate(
                Vehicle.Pedestrian.Shortest(),
                begin,
                end);

            var path = route.Select(x => x.Location());
            var distance = route.TotalDistance;

            return (path, distance);
        }

        public async Task<IEnumerable<(Coordinate Coordinate, IEnumerable<Tag> Tags)>> SelectPOIs(
            double radius,
            Coordinate center,
            IDictionary<string, IEnumerable<string>> nodeTags,
            IDictionary<string, IEnumerable<string>> wayTags)
        {
            var nodes = OsmGeos.Where(x => x is Node n && n.Distance(center) <= radius).Select(x => (Node)x);
            var ways = OsmGeos.Where(x => x is Way w && w.Nodes.Any(id => FindNode(id).Distance(center) < radius)).Select(x => (Way)x);

            var nodeTask = Task.Run(() => SelectNodePOIs(nodes, nodeTags));
            var wayTask = Task.Run(() => SelectWayPOIs(ways, wayTags));

            await Task.WhenAll(nodeTask, wayTask);

            var nodeResult = nodeTask.Result;
            var wayResult = wayTask.Result;

            return nodeResult.Concat(wayResult);
        }
    }
}
