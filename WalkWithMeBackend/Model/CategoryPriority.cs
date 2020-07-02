using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class CategoryPriority
    {
        [Required]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public double Priority { get; set; }
    }
}
