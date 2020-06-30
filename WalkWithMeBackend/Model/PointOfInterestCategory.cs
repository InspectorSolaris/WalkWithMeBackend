using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class PointOfInterestCategory
    {
        [Required]
        public Guid PointOfInterestId { get; set; }

        public PointOfInterest PointOfInterest { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
