using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Delete;
using Application.Commands.Journalists;
using Application.Exceptions;
using Application.Searches;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JorunalistsController : ControllerBase
    {
        private IDelete deleteJournalistCommand;
        private IGetJournalistCommand getJournalistCommand;
        private readonly IGetJournalistsCommand getJournalistsCommand;

        public JorunalistsController(IDelete deleteJournalistCommand, IGetJournalistCommand getJournalistCommand, IGetJournalistsCommand getJournalistsCommand)
        {
            this.deleteJournalistCommand = deleteJournalistCommand;
            this.getJournalistCommand = getJournalistCommand;
            this.getJournalistsCommand = getJournalistsCommand;

        }

        // GET: api/Jorunalists
        [HttpGet]
        public IActionResult Get([FromQuery] JournalistSearch journalistSearch)
        {
            try
            {
                var journalists = this.getJournalistsCommand.Execute(journalistSearch);
                return Ok(journalists);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Jorunalists/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = this.getJournalistCommand.Execute(id);
                return Ok(category);
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
