using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Users;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDeleteUserCommand deleteUserCommand;
        private readonly IGetUserCommand getUserCommand;
        private readonly IGetUsersCommand getUsersCommand;
        private readonly IInsertUserCommand insertUserCommand;
        private readonly IUpdateUserCommand updateUserCommand;

        public UsersController(IDeleteUserCommand deleteUserCommand, IGetUserCommand getUserCommand, IGetUsersCommand getUsersCommand, IInsertUserCommand insertUserCommand, IUpdateUserCommand updateUserCommand)
        {
            this.deleteUserCommand = deleteUserCommand;
            this.getUserCommand = getUserCommand;
            this.getUsersCommand = getUsersCommand;
            this.insertUserCommand = insertUserCommand;
            this.updateUserCommand = updateUserCommand;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch userSearch)
        {
            try
            {
                var users = this.getUsersCommand.Execute(userSearch);
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = this.getUserCommand.Execute(id);
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

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserInsertDto value)
        {
            try
            {
                this.insertUserCommand.Execute(value);
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

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserInsertDto value)
        {
            try
            {
                value.Id = id;
                this.updateUserCommand.Execute(value);
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
                this.deleteUserCommand.Execute(id);
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
