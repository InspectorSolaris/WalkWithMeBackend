using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class CategoryPriority
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public double Priority { get; set; }
    }
}
