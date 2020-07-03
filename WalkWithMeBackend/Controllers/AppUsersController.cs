using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itinero;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalkWithMeBackend.Data;
using WalkWithMeBackend.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WalkWithMeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private AppDbContext Context { get; }

        public AppUsersController(AppDbContext context)
        {
            this.Context = context;
        }

        // GET: api/<AppUserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get()
        {
            return await Context.AppUsers.ToListAsync();
        }

        // GET api/<AppUserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> Get(string id)
        {
            var appUser = await Context.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // POST api/<AppUserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AppUser appUser)
        {
            if (Context.AppUsers.Any(x => x.Id == appUser.Id))
            {
                return BadRequest();
            }

            Context.AppUsers.Add(appUser);

            await Context.SaveChangesAsync();
            return NoContent();
        }

        // PUT api/<AppUserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            var user = await Context.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return BadRequest();
            }

            user = appUser;

            await Context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<AppUserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var appUser = await Context.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (appUser == null)
            {
                return BadRequest();
            }

            Context.AppUsers.Remove(appUser);

            await Context.SaveChangesAsync();
            return NoContent();
        }
    }
}
