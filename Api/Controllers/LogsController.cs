using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Delete;
using Application.Commands.Logs;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IDelete deleteLogCommand;
        private readonly IGetLogCommand getLogCommand;
        private readonly IGetLogsCommand getLogsCommand;
        private readonly IInsertLogCommand insertLogCommand;

        public LogsController(IDelete deleteLogCommand, IGetLogCommand getLogCommand, IGetLogsCommand getLogsCommand, IInsertLogCommand insertLogCommand)
        {
            this.deleteLogCommand = deleteLogCommand;
            this.getLogCommand = getLogCommand;
            this.getLogsCommand = getLogsCommand;
            this.insertLogCommand = insertLogCommand;
        }

        // GET: api/Logs
        [HttpGet]
        public IActionResult Get([FromQuery] LogSearch logSearch)
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

        // GET: api/Logs/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = this.getLogCommand.Execute(id);
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

        // POST: api/Logs
        [HttpPost]
        public IActionResult Post([FromBody] LogDto value)
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

        // PUT: api/Logs/5
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
