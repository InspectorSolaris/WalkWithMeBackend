using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class Promocode
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid CompanyPointId { get; set; }

        public CompanyPoint CompanyPoint { get; set; }

        [Required]
        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
