using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Genders;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;
using Application.Responses;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IDeleteGenderCommand deleteGenderCommand;
        private readonly IGetGenderCommand getGenderCommand;
        private readonly IGetGendersCommand getGendersCommand;
        private readonly IInsertGenderCommand insertGenderCommand;
        private readonly IUpdateGenderCommand updateGenderCommand;

        public GendersController(IDeleteGenderCommand deleteGenderCommand, IGetGenderCommand getGenderCommand, IGetGendersCommand getGendersCommand, IInsertGenderCommand insertGenderCommand, IUpdateGenderCommand updateGenderCommand)
        {
            this.deleteGenderCommand = deleteGenderCommand;
            this.getGenderCommand = getGenderCommand;
            this.getGendersCommand = getGendersCommand;
            this.insertGenderCommand = insertGenderCommand;
            this.updateGenderCommand = updateGenderCommand;
        }

        /// <summary>
        /// Returns all genders that match provided query
        /// </summary>
        /// <param name="genderSearch"></param>
        /// <returns></returns>
        // GET: api/Genders
        [HttpGet]
        public ActionResult<PagedResponse<GenderDto>> Get([FromQuery] GenderSearch genderSearch)
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

        /// <summary>
        /// Returns specific gender based on its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Genders/5
        [HttpGet("{id}")]
        public ActionResult<GenderDto> Get(int id)
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

        /// <summary>
        /// Insert a new gender
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Genders
        [HttpPost]
        public ActionResult Post([FromBody] GenderDto value)
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

        /// <summary>
        /// Update an existing gender
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Genders/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] GenderDto value)
        {
            try
            {
                value.Id = id;
                this.updateGenderCommand.Execute(value);
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
        /// Delete some gender
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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
