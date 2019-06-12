﻿using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Stories;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;

namespace EFCommands.Stories
{
    public class EfGetStoryCommand : BaseEfCommand, IGetStoryCommand
    {
        public EfGetStoryCommand(Context context) : base(context)
        {
        }

        public StoryDto Execute(int request)
        {
            var story = this.Context.Stories.Find(request);

            if (story == null)
                throw new EntityNotFoundException("story");
            if (story.IsDeleted)
                throw new EntityNotFoundException("story");

            return new StoryDto
            {
                Id = story.Id,
                Name = story.Name,
                Description = story.Name
            };
        }
    }
}
