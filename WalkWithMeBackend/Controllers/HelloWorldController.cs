using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalkWithMeBackend.Model.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WalkWithMeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "world", "!", "GET()" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public HelloWorldDTO Get(int id)
        {
            return new HelloWorldDTO($"Hellow world! GET({id})");
        }

        // POST api/<TestController>
        [HttpPost]
        public HelloWorldDTO Post([FromBody] string value)
        {
            return new HelloWorldDTO($"Hellow world! POST({value})");
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public HelloWorldDTO Put(int id, [FromBody] string value)
        {
            return new HelloWorldDTO($"Hellow world! PUT({id}, {value})");
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public HelloWorldDTO Delete(int id)
        {
            return new HelloWorldDTO($"Hellow world! DELETE({id})");
        }
    }
}
