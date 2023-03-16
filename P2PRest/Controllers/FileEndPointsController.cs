﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2PRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileEndPointsController : ControllerBase
    {
        // GET: api/<FileEndPointsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FileEndPointsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FileEndPointsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FileEndPointsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileEndPointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
