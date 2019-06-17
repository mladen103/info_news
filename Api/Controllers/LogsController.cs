using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Logs;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;
using Application.Responses;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IDeleteLogCommand deleteLogCommand;
        private readonly IGetLogCommand getLogCommand;
        private readonly IGetLogsCommand getLogsCommand;
        private readonly IInsertLogCommand insertLogCommand;
        private readonly IUpdateLogCommand updateLogCommand;

        public LogsController(IDeleteLogCommand deleteLogCommand, IGetLogCommand getLogCommand, IGetLogsCommand getLogsCommand, IInsertLogCommand insertLogCommand, IUpdateLogCommand updateLogCommand)
        {
            this.deleteLogCommand = deleteLogCommand;
            this.getLogCommand = getLogCommand;
            this.getLogsCommand = getLogsCommand;
            this.insertLogCommand = insertLogCommand;
            this.updateLogCommand = updateLogCommand;
        }

        /// <summary>
        /// Returns all logs that match provided query
        /// </summary>
        /// <param name="logSearch"></param>
        /// <returns></returns>
        // GET: api/Logs
        [HttpGet]
        public ActionResult<PagedResponse<LogDto>> Get([FromQuery] LogSearch logSearch)
        {
            try
            {
                var logs = this.getLogsCommand.Execute(logSearch);
                return Ok(logs);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Returns specific log based on its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Logs/5
        [HttpGet("{id}")]
        public ActionResult<LogDto> Get(int id)
        {
            try
            {
                var log = this.getLogCommand.Execute(id);
                return Ok(log);
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
        /// Insert a new log
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Logs
        [HttpPost]
        public ActionResult Post([FromBody] LogDto value)
        {
            try
            {
                this.insertLogCommand.Execute(value);
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
        /// Update an existing log
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Logs/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LogDto value)
        {
            try
            {
                value.Id = id;
                this.updateLogCommand.Execute(value);
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
        /// Delete some log
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.deleteLogCommand.Execute(id);
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
