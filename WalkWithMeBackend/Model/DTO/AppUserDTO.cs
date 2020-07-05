using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model.DTO
{
    public class AppUserDTO
    {
        public AppUserDTO(AppUser appUser)
        {
            this.UserName = appUser.NormalizedUserName;
            this.Email = appUser.NormalizedEmail;
            this.Created = appUser.Created;
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Created { get; set; }
    }
}
