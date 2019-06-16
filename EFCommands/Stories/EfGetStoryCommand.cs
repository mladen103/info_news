using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Application.Commands.Stories;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Microsoft.EntityFrameworkCore;

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

            var journalists = this.Context.StoryJournalist
                .Include(j => j.Journalist)
                .Where(j => j.StoryId == request)
                .Select(j => new JournalistDto
                {
                    FirstName = j.Journalist.FirstName,
                    LastName = j.Journalist.LastName
                }).AsQueryable();

            if (story == null)
                throw new EntityNotFoundException("story");
            if (story.IsDeleted)
                throw new EntityNotFoundException("story");
            
            return new StoryDto
            {
                Id = story.Id,
                Name = story.Name,
                Description = story.Description,
                IsActive = story.IsActive,
                PicturePath = story.PicturePath,
                Journalists = journalists.ToList()
            };
        }
    }
}
