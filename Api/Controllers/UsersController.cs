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
    public class UsersController : ControllerBase
    {
        private IDelete deleteUserCommand;
        private IGetUserCommand getUserCommand;
        private readonly IGetUsersCommand getUsersCommand;

        public UsersController(IDelete deleteUserCommand, IGetUserCommand getUserCommand, IGetUsersCommand getUsersCommand)
        {
            this.deleteUserCommand = deleteUserCommand;
            this.getUserCommand = getUserCommand;
            this.getUsersCommand = getUsersCommand;

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
            catch (Exception e)
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
            catch (EntityNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
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
