using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Delete;
using Application.Commands.Get;
using Application.Exceptions;
using Application.Commands;
using Application.Searches;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private IDelete deleteLogCommand;
        private IGetLogCommand getLogCommand;
        private readonly IGetLogsCommand getLogsCommand;

        public LogsController(IDelete deleteLogCommand, IGetLogCommand getLogCommand, IGetLogsCommand getLogsCommand)
        {
            this.deleteLogCommand = deleteLogCommand;
            this.getLogCommand = getLogCommand;
            this.getLogsCommand = getLogsCommand;

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
            catch (Exception e)
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
            catch (EntityNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Logs
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
