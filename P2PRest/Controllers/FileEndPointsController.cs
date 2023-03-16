using Microsoft.AspNetCore.Mvc;
using P2PRest.Managers;
using P2PRest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2PRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileEndpointsController : ControllerBase
    {
        private FileEndpointsManager _manager = new FileEndpointsManager();

        // GET: api/<FileEndpointsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FileEndpointsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FileEndpointsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FileEndpointsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileEndpointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
