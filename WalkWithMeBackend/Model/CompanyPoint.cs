using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class CompanyPoint : PointOfInterest
    {
        [Required]
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Promocode> Promocodes { get; set; }
    }
}
