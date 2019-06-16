using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Stories;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;

namespace EFCommands.Stories
{
    public class EfInsertStoryCommand : BaseEfCommand, IInsertStoryCommand
    {
        public EfInsertStoryCommand(Context context) : base(context)
        {
        }

        public void Execute(StoryDto request)
        {
            var story = new Story
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = request.IsActive,
                CategoryId = request.CategoryId,
                PicturePath = request.PicturePath
            };

            this.Context.Stories.Add(story);
            
            this.Context.SaveChanges();
            
            foreach (var item in request.Journalists)
            {
                this.Context.StoryJournalist.Add(new StoryJournalist
                {
                    JournalistId = item.Id,
                    StoryId = story.Id
                });
            }

            this.Context.SaveChanges();
        }
    }
}
