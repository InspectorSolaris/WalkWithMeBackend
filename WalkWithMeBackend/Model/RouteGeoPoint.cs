using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class RouteGeoPoint
    {
        [Required]
        public Guid RouteId { get; set; }

        public Route Route { get; set; }

        [Required]
        public Guid GeoPointId { get; set; }

        public GeoPoint GeoPoint { get; set; }
    }
}
