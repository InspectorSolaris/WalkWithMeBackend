using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itinero;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalkWithMeBackend.Data;
using WalkWithMeBackend.Model;
using WalkWithMeBackend.Model.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WalkWithMeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private UserManager<AppUser> UserManager { get; set; }

        public AppUsersController(UserManager<AppUser> userManager)
        {
            this.UserManager = userManager;
        }

        // GET: api/<AppUserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserDTO>>> Get()
        {
            return await UserManager.Users
                .Select(x => new AppUserDTO(x))
                .ToListAsync();
        }

        // GET api/<AppUserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserDTO>> Get(string id)
        {
            var appUser = await UserManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            return new AppUserDTO(appUser);
        }

        // POST api/<AppUserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppUserDTO appUserDTO)
        {
            var appUser = new AppUser
            {
                UserName = appUserDTO.UserName,
                Email = appUserDTO.Email,
                Created = DateTime.Now
            };

            var result = await UserManager.CreateAsync(appUser, appUserDTO.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // PUT api/<AppUserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] AppUserDTO appUserDTO)
        {
            var appUser = await UserManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return BadRequest();
            }

            appUser.UserName = appUserDTO.UserName;
            appUser.Email = appUserDTO.Email;

            if (appUserDTO.Password != null)
            {
                var resetToken = await UserManager.GeneratePasswordResetTokenAsync(appUser);
                var resetResult = await UserManager.ResetPasswordAsync(appUser, resetToken, appUserDTO.Password);
                if (!resetResult.Succeeded)
                {
                    return BadRequest();
                }
            }

            var result = await UserManager.UpdateAsync(appUser);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE api/<AppUserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var appUser = await UserManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return BadRequest();
            }

            var result = await UserManager.DeleteAsync(appUser);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
