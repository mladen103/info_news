using System;
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
                throw new EntityNotFoundException("story");
            if (story.IsDeleted)
                throw new EntityNotFoundException("story");
            
            if (story.Name != request.Name)
                story.Name = request.Name;
            if (story.Description != request.Description)
                story.Description = request.Description;
            if (story.IsActive != request.IsActive)
                story.IsActive = request.IsActive;
            if (request.PicturePath != null && story.PicturePath != request.PicturePath)
                story.PicturePath = request.PicturePath;

            if (story.CategoryId != request.CategoryId)
                story.CategoryId = request.CategoryId;

            var storyJournalists = this.Context.StoryJournalist.Where(sj => sj.StoryId == story.Id);
            this.Context.StoryJournalist.RemoveRange(storyJournalists);

            //for (int i= 0; i < storyJournalistCount; i++)
            //{
            //    var storyJournalist = this.Context.StoryJournalist.Where(sj => sj.JournalistId == item.Id && sj.StoryId == story.Id).FirstOrDefault();
            //    this.Context.StoryJournalist.Remove();
            //}

            foreach (var item in request.Journalists)
            {
                this.Context.StoryJournalist.Add(new StoryJournalist
                {
                    JournalistId = item.Id,
                    StoryId = story.Id
                });
            }
            
            story.ModifiedAt = DateTime.Now;

            this.Context.SaveChanges();
        }
    }
}
