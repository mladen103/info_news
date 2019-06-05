using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Delete;
using Application.Commands.Get;
using Application.Exceptions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JorunalistsController : ControllerBase
    {
        private IDelete deleteJournalistCommand;
        private IGetJournalistCommand getJournalistCommand;

        public JorunalistsController(IDelete deleteJournalistCommand, IGetJournalistCommand getJournalistCommand)
        {
            this.deleteJournalistCommand = deleteJournalistCommand;
            this.getJournalistCommand = getJournalistCommand;
        }

        // GET: api/Jorunalists
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Jorunalists/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Jorunalists
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Jorunalists/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.deleteJournalistCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
