using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Stories;
using Application.Exceptions;
using Application.Searches;
using Application.DataTransferObjects;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IDeleteStoryCommand deleteStoryCommand;
        private readonly IGetStoryCommand getStoryCommand;
        private readonly IGetStoriesCommand getStoriesCommand;
        private readonly IInsertStoryCommand insertStoryCommand;
        private readonly IUpdateStoryCommand updateStoryCommand;

        public StoriesController(IDeleteStoryCommand deleteStoryCommand, IGetStoryCommand getStoryCommand, IGetStoriesCommand getStoriesCommand, IInsertStoryCommand insertStoryCommand, IUpdateStoryCommand updateStoryCommand)
        {
            this.deleteStoryCommand = deleteStoryCommand;
            this.getStoryCommand = getStoryCommand;
            this.getStoriesCommand = getStoriesCommand;
            this.insertStoryCommand = insertStoryCommand;
            this.updateStoryCommand = updateStoryCommand;
        }

        // GET: api/Stories
        [HttpGet]
        public IActionResult Get([FromQuery] StorySearch storySearch)
        {
            try
            {
                var stories = this.getStoriesCommand.Execute(storySearch);
                return Ok(stories);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Stories/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = this.getStoryCommand.Execute(id);
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

        // POST: api/Stories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Stories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StoryDto value)
        {
            try
            {
                value.Id = id;
                this.updateStoryCommand.Execute(value);
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
                this.deleteStoryCommand.Execute(id);
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
