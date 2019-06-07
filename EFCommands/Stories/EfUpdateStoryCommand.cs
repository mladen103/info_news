﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Application.Commands.Stories;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EFCommands.Stories
{
    public class EfUpdateStoryCommand : BaseEfCommand, IUpdateStoryCommand
    {
        public EfUpdateStoryCommand(Context context) : base(context)
        {
        }

        public void Execute(StoryDto request)
        {
            var story = this.Context.Stories.Find(request.Id);
            if (story == null)
                throw new EntityNotFoundException();

            var stories = this.Context.Stories;
            
            if (story.Name != request.Name)
                story.Name = request.Name;
            if (story.Description != request.Description)
                story.Description = request.Description;
            
            this.Context.SaveChanges();
        }
    }
}