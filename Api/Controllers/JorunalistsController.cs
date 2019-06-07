﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Delete;
using Application.Commands.Journalists;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JorunalistsController : ControllerBase
    {
        private readonly IDelete deleteJournalistCommand;
        private readonly IGetJournalistCommand getJournalistCommand;
        private readonly IGetJournalistsCommand getJournalistsCommand;
        private readonly IInsertJournalistCommand insertJournalistCommand;

        public JorunalistsController(IDelete deleteJournalistCommand, IGetJournalistCommand getJournalistCommand, IGetJournalistsCommand getJournalistsCommand, IInsertJournalistCommand insertJournalistCommand)
        {
            this.deleteJournalistCommand = deleteJournalistCommand;
            this.getJournalistCommand = getJournalistCommand;
            this.getJournalistsCommand = getJournalistsCommand;
            this.insertJournalistCommand = insertJournalistCommand;
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
