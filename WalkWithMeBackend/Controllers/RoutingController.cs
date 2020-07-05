using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itinero.LocalGeo;
using Microsoft.AspNetCore.Mvc;
using WalkWithMeBackend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WalkWithMeBackend.Controllers
{
    //public class RouteCoordinates
    //{
    //    public float BeginLatitude { get; set; }

    //    public float BeginLongitude { get; set; }

    //    public float EndLatitude { get; set; }

    //    public float EndLongitude { get; set; }
    //}

    //[Route("api/[controller]")]
    //[ApiController]
    //public class RoutingController : ControllerBase
    //{
    //    private OsmService OsmService { get; set; }

    //    private GeneticService GeneticService { get; set; }

    //    public RoutingController(
    //        OsmService osmService,
    //        GeneticService geneticService)
    //    {
    //        this.OsmService = osmService;
    //        this.GeneticService = geneticService;
    //    }

    //    // POST api/<RoutingController>
    //    [HttpPost]
    //    public async Task<IEnumerable<(float Latitude, float Longitude)>> Post([FromBody] RouteCoordinates routeCoordinates)
    //    {
    //        var begin = new Coordinate(routeCoordinates.BeginLatitude, routeCoordinates.BeginLongitude);
    //        var end = new Coordinate(routeCoordinates.BeginLatitude, routeCoordinates.BeginLongitude);

    //        var dX = Math.Abs(begin.Latitude - end.Latitude);
    //        var dY = Math.Abs(begin.Longitude - end.Longitude);
    //        var centerX = (begin.Latitude + end.Latitude) / 2;
    //        var centerY = (begin.Longitude + end.Longitude) / 2;

    //        var radius = Math.Sqrt(dX * dX + dY * dY) / 2;
    //        var center = new Coordinate(centerX, centerY);

    //        var pois = (await OsmService.SelectPOIs(radius, center, new Dictionary<string, IEnumerable<string>>(), new Dictionary<string, IEnumerable<string>>())).ToList();
    //        var graph = new List<List<double>>();
    //        var interest = new List<double>();

    //        for (int i = 0; i < pois.Count; ++i)
    //        {
    //            graph.Add(Enumerable.Repeat(0.0, pois.Count).ToList());
    //            interest.Add(1.0);

    //            for (int j = 0; j < i; ++j)
    //            {
    //                var poi1 = pois[i].Coordinate;
    //                var poi2 = pois[j].Coordinate;
    //                var (Path, Distance) = OsmService.BuildRoute(poi1, poi2);

    //                graph[i][j] = Distance;
    //                graph[j][i] = Distance;
    //            }
    //        }

    //        return GeneticService.Run(graph, interest)
    //            .Select(i => (pois[i].Coordinate.Latitude, pois[i].Coordinate.Longitude));
    //    }
    //}
}
