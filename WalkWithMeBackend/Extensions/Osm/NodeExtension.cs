using Itinero.LocalGeo;
using OsmSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Extensions.Osm
{
    public static class NodeExtension
    {
        public static double Distance(
            this Node node,
            Coordinate coordinate)
        {
            var dx = (double)node.Latitude - coordinate.Latitude;
            var dy = (double)node.Longitude - coordinate.Longitude;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
