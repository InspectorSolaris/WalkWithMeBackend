using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class Score
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public long Amount { get; set; }
    }
}
