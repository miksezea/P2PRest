using Microsoft.AspNetCore.Mvc;
using P2PRest.Repositories;
using P2PRest.Models;

namespace P2PRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileEndpointsController : ControllerBase
    {
        private FileEndpointsRepository _repository = new FileEndpointsRepository();

        // GET: api/<FileEndpointsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<string> result = _repository.GetFileNames();
            if (result == null || result.Count() <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        // GET api/<FileEndpointsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{filename}")]
        public ActionResult<IEnumerable<FileEndpoint>> Get(string filename)
        {
            IEnumerable<FileEndpoint> endpoints = _repository.GetEndpoints(filename);
            if (endpoints == null || endpoints.Count() <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(endpoints);
            }
        }

        // POST api/<FileEndpointsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<FileEndpoint> Post([FromBody] FileEndpoint newFileEndpoint)
        {
            FileEndpoint createdFileEndpoint = _repository.AddEndpoint(newFileEndpoint);
            if (createdFileEndpoint == null)
            {
                return BadRequest();
            }
            else
            {
                return Created($"api/fileendpoints/{createdFileEndpoint.FileName}", createdFileEndpoint);
            }
        }

        // DELETE api/<FileEndpointsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{filename}/{ip}/{port}")]
        public ActionResult<FileEndpoint> Delete(string filename, string ip, int port)
        {
            FileEndpoint? deletedFile = _repository.DeleteEndpoint(filename, ip, port);
            if (deletedFile == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deletedFile);
            }
        }
    }
}
