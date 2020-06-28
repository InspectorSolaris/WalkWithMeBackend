using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class RouteGeoPoint
    {
        public Guid RouteId { get; set; }

        public Route Route { get; set; }

        public Guid GeoPointId { get; set; }

        public GeoPoint GeoPoint { get; set; }
    }
}
