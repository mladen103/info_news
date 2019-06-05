using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Delete;
using Application.Commands.Get;
using Application.Exceptions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private IDelete deleteCategoryCommand;
        private IGetCategoryCommand getCategoryCommand;

        public CategoriesController(IDelete deleteCategoryCommand, IGetCategoryCommand getCategoryCommand)
        {
            this.deleteCategoryCommand = deleteCategoryCommand;
            this.getCategoryCommand = getCategoryCommand;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var category = this.getCategoryCommand.Execute(id);
                return Ok(category);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound();
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }

        }

        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.deleteCategoryCommand.Execute(id);

            return NoContent();
        }
    }
}
