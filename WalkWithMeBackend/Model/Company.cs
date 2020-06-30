using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public IEnumerable<CompanyPoint> CompanyPoints { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
