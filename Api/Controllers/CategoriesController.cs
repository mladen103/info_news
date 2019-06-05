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
    public class CategoriesController : ControllerBase
    {
        private readonly IDelete deleteCategoryCommand;
        private readonly IGetCategoryCommand getCategoryCommand;
        private readonly IGetCategoriesCommand getCategoriesCommand;
        
        public CategoriesController(IDelete deleteCategoryCommand, IGetCategoryCommand getCategoryCommand, IGetCategoriesCommand getCategoriesCommand)
        {
            this.deleteCategoryCommand = deleteCategoryCommand;
            this.getCategoryCommand = getCategoryCommand;
            this.getCategoriesCommand = getCategoriesCommand;

        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch categorySearch)
        {
            try
            {
                var categories = this.getCategoriesCommand.Execute(categorySearch);
                return Ok(categories);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
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
            try
            {
                this.deleteCategoryCommand.Execute(id);
                return NoContent();
            }
            catch(EntityNotFoundException)
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
