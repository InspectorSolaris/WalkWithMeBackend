using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class GeoPoint
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public IEnumerable<RouteGeoPoint> Routes { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}
