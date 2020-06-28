using OsmSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class PointOfInterest : GeoPoint
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
