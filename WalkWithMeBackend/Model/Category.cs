using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public IEnumerable<PointOfInterestCategory> PointOfInterests { get; set; }

        public IEnumerable<CategoryPriority> CategoryPriorities { get; set; }

        public string Name { get; set; }
    }
}
