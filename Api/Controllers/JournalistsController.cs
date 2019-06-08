using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Journalists;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalistsController : ControllerBase
    {
        private readonly IDeleteJournalistCommand deleteJournalistCommand;
        private readonly IGetJournalistCommand getJournalistCommand;
        private readonly IGetJournalistsCommand getJournalistsCommand;
        private readonly IInsertJournalistCommand insertJournalistCommand;
        private readonly IUpdateJournalistCommand updateJournalistCommand;

        public JournalistsController(IDeleteJournalistCommand deleteJournalistCommand, IGetJournalistCommand getJournalistCommand, IGetJournalistsCommand getJournalistsCommand, IInsertJournalistCommand insertJournalistCommand, IUpdateJournalistCommand updateJournalistCommand)
        {
            this.deleteJournalistCommand = deleteJournalistCommand;
            this.getJournalistCommand = getJournalistCommand;
            this.getJournalistsCommand = getJournalistsCommand;
            this.insertJournalistCommand = insertJournalistCommand;
            this.updateJournalistCommand = updateJournalistCommand;
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
        public IActionResult Post([FromBody] JournalistDto value)
        {
            try
            {
                this.insertJournalistCommand.Execute(value);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Jorunalists/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] JournalistDto value)
        {
            try
            {
                value.Id = id;
                this.updateJournalistCommand.Execute(value);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (EntityAlreadyExistsException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
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
