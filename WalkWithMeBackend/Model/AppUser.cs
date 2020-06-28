﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model
{
    public class AppUser : IdentityUser
    {
        public DateTime Created { get; set; }

        public IEnumerable<Route> Routes { get; set; }

        public IEnumerable<CategoryPriority> CategoryPriorities { get; set; }

        public IEnumerable<Score> Scores { get; set; }
    }
}
