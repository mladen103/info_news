using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Categories;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IDeleteCategoryCommand deleteCategoryCommand;
        private readonly IGetCategoryCommand getCategoryCommand;
        private readonly IGetCategoriesCommand getCategoriesCommand;
        private readonly IInsertCategoryCommand insertCategoryCommand;
        private readonly IUpdateCategoryCommand updateCategoryCommand;

        public CategoriesController(IDeleteCategoryCommand deleteCategoryCommand, IGetCategoryCommand getCategoryCommand, IGetCategoriesCommand getCategoriesCommand, IInsertCategoryCommand insertCategoryCommand, IUpdateCategoryCommand updateCategoryCommand)
        {
            this.deleteCategoryCommand = deleteCategoryCommand;
            this.getCategoryCommand = getCategoryCommand;
            this.getCategoriesCommand = getCategoriesCommand;
            this.insertCategoryCommand = insertCategoryCommand;
            this.updateCategoryCommand = updateCategoryCommand;
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
            catch (Exception)
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
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }

        }

        // POST: api/Categories
        [HttpPost]
        public ActionResult Post([FromBody] CategoryDto value)
        {
            try
            {
                this.insertCategoryCommand.Execute(value);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                if (e.Message == "The chosen category already exists.")
                {
                    return Conflict(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto value)
        {
            try
            {
                value.Id = id;
                this.updateCategoryCommand.Execute(value);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if(e.Message == "The chosen category not found.")
                    return NotFound(e.Message);
                return UnprocessableEntity(e.Message);
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e.Message);
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
