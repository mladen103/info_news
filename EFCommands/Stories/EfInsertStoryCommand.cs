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
            if(!this.Context.Categories.Any(c => c.Id == request.CategoryId))
            {
                throw new EntityNotFoundException("category");
            }
            
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
                if(!this.Context.Journalists.Any(j => j.Id == item.Id))
                {
                    throw new EntityNotFoundException("journalist");
                }

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
