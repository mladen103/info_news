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

namespace WebApp.Controllers
{
    public class StoriesController : Controller
    {
        private readonly IInsertStoryCommand insertStoryCommand;
        private readonly IGetStoriesCommand getStoriesCommand;
        private readonly IDeleteStoryCommand deleteStoryCommand;
        private readonly IGetStoryCommand getStoryCommand;
        private readonly IUpdateStoryCommand updateStoryCommand;

        public StoriesController(IInsertStoryCommand insertStoryCommand, IGetStoriesCommand getStoriesCommand, IDeleteStoryCommand deleteStoryCommand, IGetStoryCommand getStoryCommand, IUpdateStoryCommand updateStoryCommand)
        {
            this.insertStoryCommand = insertStoryCommand;
            this.getStoriesCommand = getStoriesCommand;
            this.deleteStoryCommand = deleteStoryCommand;
            this.getStoryCommand = getStoryCommand;
            this.updateStoryCommand = updateStoryCommand;
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
            return View();
        }

        // POST: Stories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryDto story)
        {
            var fajl = Request.Form.Files["fajl"];
            var ext = Path.GetExtension(fajl.ToString()); //.gif

            var newFileName = Guid.NewGuid().ToString() + "_" + fajl.FileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);
            fajl.CopyTo(new FileStream(filePath, FileMode.Create));

            PictureDto p = new PictureDto();
            p.Name = story.Name;
            p.Path = filePath;
            
            story.Picture = new Domain.Picture { Name = p.Name, Path = p.Path };

            this.insertStoryCommand.Execute(story);

            return View();
        }

        // GET: Stories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}