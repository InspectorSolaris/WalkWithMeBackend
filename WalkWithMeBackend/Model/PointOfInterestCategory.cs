using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class PointOfInterestCategory
    {
        public Guid PointOfInterestId { get; set; }

        public PointOfInterest PointOfInterest { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
