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
using Application.Responses;

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

        /// <summary>
        /// Returns all users that match provided query
        /// </summary>
        /// <param name="userSearch"></param>
        /// <returns></returns>
        // GET: api/Users
        [HttpGet]
        public ActionResult<PagedResponse<UserGetDto>> Get([FromQuery] UserSearch userSearch)
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

        /// <summary>
        /// Returns specific user based on his identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserGetDto> Get(int id)
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

        /// <summary>
        /// Insert a new user
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Users
        [HttpPost]
        public ActionResult Post([FromBody] UserInsertDto value)
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
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserInsertDto value)
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

        /// <summary>
        /// Delete some user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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
