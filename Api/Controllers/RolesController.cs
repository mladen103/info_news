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
    public class RolesController : ControllerBase
    {
        private IDelete deleteRoleCommand;
        private IGetRoleCommand getRoleCommand;
        private readonly IGetRolesCommand getRolesCommand;

        public RolesController(IDelete deleteRoleCommand, IGetRoleCommand getRoleCommand, IGetRolesCommand getRolesCommand)
        {
            this.deleteRoleCommand = deleteRoleCommand;
            this.getRoleCommand = getRoleCommand;
            this.getRolesCommand = getRolesCommand;

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
            catch (EntityNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Roles
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
