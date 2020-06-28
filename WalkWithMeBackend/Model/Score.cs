using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class Score
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public DateTime Date { get; set; }

        public long Amount { get; set; }
    }
}
