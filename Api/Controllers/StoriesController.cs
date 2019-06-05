﻿using System;
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
    public class StoriesController : ControllerBase
    {
        private IDelete deleteStoryCommand;
        private IGetStoryCommand getStoryCommand;

        public StoriesController(IDelete deleteStoryCommand, IGetStoryCommand getStoryCommand)
        {
            this.deleteStoryCommand = deleteStoryCommand;
            this.getStoryCommand = getStoryCommand;
        }

        // GET: api/Stories
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Stories/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Stories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}