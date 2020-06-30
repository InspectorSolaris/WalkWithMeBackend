using OsmSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class Route
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public IEnumerable<RouteGeoPoint> GeoPoints { get; set; }

        [Required]
        public double Length { get; set; }
    }
}
