using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Roles;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;
using Application.Responses;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IDeleteRoleCommand deleteRoleCommand;
        private readonly IGetRoleCommand getRoleCommand;
        private readonly IGetRolesCommand getRolesCommand;
        private readonly IInsertRoleCommand insertRoleCommand;
        private readonly IUpdateRoleCommand updateRoleCommand;

        public RolesController(IDeleteRoleCommand deleteRoleCommand, IGetRoleCommand getRoleCommand, IGetRolesCommand getRolesCommand, IInsertRoleCommand insertRoleCommand, IUpdateRoleCommand updateRoleCommand)
        {
            this.deleteRoleCommand = deleteRoleCommand;
            this.getRoleCommand = getRoleCommand;
            this.getRolesCommand = getRolesCommand;
            this.insertRoleCommand = insertRoleCommand;
            this.updateRoleCommand = updateRoleCommand;
        }

        /// <summary>
        /// Returns all roles that match provided query
        /// </summary>
        /// <param name="roleSearch"></param>
        /// <returns></returns>
        // GET: api/Roles
        [HttpGet]
        public ActionResult<PagedResponse<RoleDto>> Get([FromQuery] RoleSearch roleSearch)
        {
            try
            {
                var roles = this.getRolesCommand.Execute(roleSearch);
                return Ok(roles);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Returns specific role based on its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Roles/5
        [HttpGet("{id}")]
        public ActionResult<RoleDto> Get(int id)
        {
            try
            {
                var category = this.getRoleCommand.Execute(id);
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
        /// Insert a new role
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Roles
        [HttpPost]
        public ActionResult Post([FromBody] RoleDto value)
        {
            try
            {
                this.insertRoleCommand.Execute(value);
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
        /// Update an existing role
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RoleDto value)
        {
            try
            {
                value.Id = id;
                this.updateRoleCommand.Execute(value);
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
        /// Delete some role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.deleteRoleCommand.Execute(id);
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
