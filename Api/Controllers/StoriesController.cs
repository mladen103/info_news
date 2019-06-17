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
using System.IO;
using Api.Models;
using Application.Helpers;
using Application.Commands.Journalists;
using Application.Responses;

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

        private readonly IGetJournalistCommand getJournalistCommand;

        public StoriesController(IDeleteStoryCommand deleteStoryCommand, IGetStoryCommand getStoryCommand, IGetStoriesCommand getStoriesCommand, IInsertStoryCommand insertStoryCommand, IUpdateStoryCommand updateStoryCommand, IGetJournalistCommand getJournalistCommand)
        {
            this.deleteStoryCommand = deleteStoryCommand;
            this.getStoryCommand = getStoryCommand;
            this.getStoriesCommand = getStoriesCommand;
            this.insertStoryCommand = insertStoryCommand;
            this.updateStoryCommand = updateStoryCommand;
            this.getJournalistCommand = getJournalistCommand;
        }

        /// <summary>
        /// Returns all stories that match provided query
        /// </summary>
        /// <param name="storySearch"></param>
        /// <returns></returns>
        // GET: api/Stories
        [HttpGet]
        public ActionResult<PagedResponse<StoryDto>> Get([FromQuery] StorySearch storySearch)
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

        /// <summary>
        /// Returns specific story based on its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Stories/5
        [HttpGet("{id}")]
        public ActionResult<StoryDto> Get(int id)
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

        /// <summary>
        /// Insert a new story
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        // POST: api/Stories
        [HttpPost]
        public ActionResult Post([FromForm] StoryInsertDto story)
        {
            var extension = Path.GetExtension(story.Picture.FileName);

            if (!FileUpload.AllowedExtensions.Contains(extension))
            {
                return UnprocessableEntity("You must upload image.");
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + story.Picture.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);
                story.Picture.CopyTo(new FileStream(filePath, FileMode.Create));

                List<JournalistDto> journalists = new List<JournalistDto>();
                foreach (var journalistId in story.Journalists)
                {
                    journalists.Add(this.getJournalistCommand.Execute(journalistId));
                }

                StoryDto storyDto = new StoryDto
                {
                    IsActive = story.IsActive,
                    Name = story.Name,
                    Description = story.Description,
                    PicturePath = newFileName,
                    CategoryId = story.CategoryId,
                    Journalists = journalists
                };

                this.insertStoryCommand.Execute(storyDto);

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
        /// Update an existing story
        /// </summary>
        /// <param name="id"></param>
        /// <param name="story"></param>
        /// <returns></returns>
        // PUT: api/Stories/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] StoryInsertDto story)
        {
            story.Id = id;

            try
            {
                string newFileName = null;
                if (story.Picture != null)
                {
                    var extension = Path.GetExtension(story.Picture.FileName);

                    if (!FileUpload.AllowedExtensions.Contains(extension))
                    {
                        return UnprocessableEntity("You must upload image.");
                    }

                    newFileName = Guid.NewGuid().ToString() + "_" + story.Picture.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);
                    story.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                List<JournalistDto> journalists = new List<JournalistDto>();
                foreach (var journalistId in story.Journalists)
                {
                    journalists.Add(this.getJournalistCommand.Execute(journalistId));
                }

                StoryDto storyDto = new StoryDto
                {
                    Id = story.Id,
                    IsActive = story.IsActive,
                    Name = story.Name,
                    Description = story.Description,
                    PicturePath = newFileName,
                    CategoryId = story.CategoryId,
                    Journalists = journalists
                };

                this.updateStoryCommand.Execute(storyDto);
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
        /// Delete some story
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
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
