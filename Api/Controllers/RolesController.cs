using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Delete;
using Application.Commands.Roles;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IDelete deleteRoleCommand;
        private readonly IGetRoleCommand getRoleCommand;
        private readonly IGetRolesCommand getRolesCommand;
        private readonly IInsertRoleCommand insertRoleCommand;

        public RolesController(IDelete deleteRoleCommand, IGetRoleCommand getRoleCommand, IGetRolesCommand getRolesCommand, IInsertRoleCommand insertRoleCommand)
        {
            this.deleteRoleCommand = deleteRoleCommand;
            this.getRoleCommand = getRoleCommand;
            this.getRolesCommand = getRolesCommand;
            this.insertRoleCommand = insertRoleCommand;
        }

        // GET: api/Roles
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch roleSearch)
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

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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

        // POST: api/Roles
        [HttpPost]
        public IActionResult Post([FromBody] RoleDto value)
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

        // PUT: api/Roles/5
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
