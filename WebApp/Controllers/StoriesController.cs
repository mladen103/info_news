using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Commands.Stories;
using Application.Searches;
using Application.DataTransferObjects;
using System.IO;
using Application.Commands.Journalists;
using WebApp.Models;
using Application.Helpers;
using Application.Commands.Categories;
using Application.Commands.StoriesJournalists;

namespace WebApp.Controllers
{
    public class StoriesController : Controller
    {
        private readonly IInsertStoryCommand insertStoryCommand;
        private readonly IGetStoriesCommand getStoriesCommand;
        private readonly IDeleteStoryCommand deleteStoryCommand;
        private readonly IGetStoryCommand getStoryCommand;
        private readonly IUpdateStoryCommand updateStoryCommand;

        private readonly IGetJournalistsCommand getJournalistsCommand;
        private readonly IGetJournalistCommand getJournalistCommand;
        private readonly IGetCategoriesCommand getCategoriesCommand;
        
        public StoriesController(IInsertStoryCommand insertStoryCommand, IGetStoriesCommand getStoriesCommand, IDeleteStoryCommand deleteStoryCommand, IGetStoryCommand getStoryCommand, IUpdateStoryCommand updateStoryCommand, IGetJournalistsCommand getJournalistsCommand, IGetCategoriesCommand getCategoriesCommand, IGetJournalistCommand getJournalistCommand)
        {
            this.insertStoryCommand = insertStoryCommand;
            this.getStoriesCommand = getStoriesCommand;
            this.deleteStoryCommand = deleteStoryCommand;
            this.getStoryCommand = getStoryCommand;
            this.updateStoryCommand = updateStoryCommand;
            this.getJournalistsCommand = getJournalistsCommand;
            this.getCategoriesCommand = getCategoriesCommand;
            this.getJournalistCommand = getJournalistCommand;
        }

        // GET: Stories
        public ActionResult Index(StorySearch storySearch)
        {
            var stories = this.getStoriesCommand.Execute(storySearch);
            return View(stories);
        }

        // GET: Stories/Details/5
        public ActionResult Details(int id)
        {
            var story = this.getStoryCommand.Execute(id);
            return View(story);
        }

        // GET: Stories/Create
        public ActionResult Create()
        {
            ViewBag.Journalists = this.getJournalistsCommand.Execute(new JournalistSearch()).Data;
            ViewBag.Categories = this.getCategoriesCommand.Execute(new CategorySearch()).Data;

            return View();
        }

        // POST: Stories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] StoryInsertDto story)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

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
                foreach(var journalistId in story.Journalists)
                {
                    journalists.Add(this.getJournalistCommand.Execute(journalistId));
                }

                StoryDto storyDto = new StoryDto {
                    IsActive = story.IsActive,
                    Name = story.Name,
                    Description = story.Description,
                    PicturePath = newFileName,
                    CategoryId = story.CategoryId,
                    Journalists = journalists
                };
                
                this.insertStoryCommand.Execute(storyDto);

                return View();
            }
            catch (Exception e)
            {
                string asd = e.Message;
                TempData["error"] = "An error has occured.";
            }

            return View();


        }

        // GET: Stories/Edit/5
        public ActionResult Edit(int id)
        {
            var story = this.getStoryCommand.Execute(id);
            StoryInsertDto storyInsertDto = new StoryInsertDto
            {
                CategoryId = story.CategoryId,
                Description = story.Description,
                IsActive = story.IsActive,
                Name = story.Name,
                Journalists = story.Journalists.Select(j => j.Id)
            };

            ViewBag.Journalists = this.getJournalistsCommand.Execute(new JournalistSearch()).Data;
            ViewBag.Categories = this.getCategoriesCommand.Execute(new CategorySearch()).Data;

            return View(storyInsertDto);
        }

        // POST: Stories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] StoryInsertDto story)
        {
            story.Id = id;

            if (!ModelState.IsValid)
            {
                return View();
            }
            
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
                
            }
            catch (Exception e)
            {
                string asd = e.Message;
                TempData["error"] = "An error has occured.";
            }
            
            return RedirectToAction(nameof(Index));
            
        }

        // POST: Stories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                this.deleteStoryCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}