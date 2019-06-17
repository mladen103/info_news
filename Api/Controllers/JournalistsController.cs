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
using Application.Responses;

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

        /// <summary>
        /// Returns all journalists that match provided query
        /// </summary>
        /// <param name="journalistSearch"></param>
        /// <returns></returns>
        // GET: api/Jorunalists
        [HttpGet]
        public ActionResult<PagedResponse<JournalistDto>> Get([FromQuery] JournalistSearch journalistSearch)
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

        /// <summary>
        /// Returns specific journalist based on his/her identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Jorunalists/5
        [HttpGet("{id}")]
        public ActionResult<JournalistDto> Get(int id)
        {
            try
            {
                var journalist = this.getJournalistCommand.Execute(id);
                return Ok(journalist);
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

        /// <summary>
        /// Insert a new journalist
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Jorunalists
        [HttpPost]
        public ActionResult Post([FromBody] JournalistDto value)
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

        /// <summary>
        /// Update an existing journalist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Jorunalists/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] JournalistDto value)
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

        /// <summary>
        /// Delete some journalist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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
