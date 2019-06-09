using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Journalists;
using Application.DataTransferObjects;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class JournalistsController : Controller
    {
        private readonly IDeleteJournalistCommand deleteJournalistCommand;
        private readonly IGetJournalistCommand getJournalistCommand;
        private readonly IGetJournalistsCommand getJournalistsCommand;
        private readonly IInsertJournalistCommand insertJournalistCommand;
        private readonly IUpdateJournalistCommand updateJournalistCommand;

        public JournalistsController(IDeleteJournalistCommand deleteJournalistCommand, IGetJournalistCommand getJournalistCommand, IGetJournalistsCommand getJournalistsCommand, IInsertJournalistCommand insertJournalistCommand, IUpdateJournalistCommand updateJournalistCommand)
        {
            this.deleteJournalistCommand = deleteJournalistCommand;
            this.getJournalistCommand = getJournalistCommand;
            this.getJournalistsCommand = getJournalistsCommand;
            this.insertJournalistCommand = insertJournalistCommand;
            this.updateJournalistCommand = updateJournalistCommand;
        }

        // GET: Journalists
        public IActionResult Index(JournalistSearch search)
        {
            var journalists = this.getJournalistsCommand.Execute(search);
            return View(journalists);
        }

        // GET: Journalists/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var journalist = this.getJournalistCommand.Execute(id);
                return View(journalist);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Journalists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Journalists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JournalistDto journalist)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                try
                {
                    this.insertJournalistCommand.Execute(journalist);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    TempData["error"] = "An error has occured.";
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Journalists/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var journalist = this.getJournalistCommand.Execute(id);
                return View(journalist);
            }
            catch (EntityNotFoundException e)
            {
                return RedirectToAction("index");
            }
        }

        // POST: Journalists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JournalistDto journalist)
        {
            if (!ModelState.IsValid)
            {
                return View(journalist);
            }

            try
            {
                this.updateJournalistCommand.Execute(journalist);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Journalist already exists.";
                return View(journalist);
            }
        }
        
        // POST: Journalists/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                this.deleteJournalistCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}