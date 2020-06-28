using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class GeoPoint
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public IEnumerable<RouteGeoPoint> Routes { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
