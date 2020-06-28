using OsmSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class Route
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public IEnumerable<RouteGeoPoint> GeoPoints { get; set; }

        public double Length { get; set; }
    }
}
