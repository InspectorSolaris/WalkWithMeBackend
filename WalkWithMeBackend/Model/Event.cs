using OsmSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class Event : PointOfInterest
    {
        [Required]
        public DateTime Begin { get; set; }

        [Required]
        public DateTime End { get; set; }
    }
}
