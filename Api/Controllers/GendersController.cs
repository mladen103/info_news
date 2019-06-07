using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Delete;
using Application.Commands.Genders;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IDelete deleteGenderCommand;
        private readonly IGetGenderCommand getGenderCommand;
        private readonly IGetGendersCommand getGendersCommand;
        private readonly IInsertGenderCommand insertGenderCommand;

        public GendersController(IDelete deleteGenderCommand, IGetGenderCommand getGenderCommand, IGetGendersCommand getGendersCommand, IInsertGenderCommand insertGenderCommand)
        {
            this.deleteGenderCommand = deleteGenderCommand;
            this.getGenderCommand = getGenderCommand;
            this.getGendersCommand = getGendersCommand;
            this.insertGenderCommand = insertGenderCommand;
        }

        // GET: api/Genders
        [HttpGet]
        public IActionResult Get([FromQuery] GenderSearch genderSearch)
        {
            try
            {
                var genders = this.getGendersCommand.Execute(genderSearch);
                return Ok(genders);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = this.getGenderCommand.Execute(id);
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

        // POST: api/Genders
        [HttpPost]
        public IActionResult Post([FromBody] GenderDto value)
        {
            try
            {
                this.insertGenderCommand.Execute(value);
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

        // PUT: api/Genders/5
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
                this.deleteGenderCommand.Execute(id);
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
