using OsmSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class PointOfEvent : GeoPoint
    {
        public string Name { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }
    }
}
