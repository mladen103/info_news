using Application.Commands.StoriesJournalists;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.StoriesJournalists
{
    public class EfInsertStoryJournalistCommand : BaseEfCommand, IInsertStoryJournalistCommand
    {
        public EfInsertStoryJournalistCommand(Context context) : base(context)
        {
        }

        public void Execute(StoryJournalistDto request)
        {
            var storyJournalist = this.Context.StoryJournalist.Where(sj => sj.JournalistId == request.JournalistId && sj.StoryId == request.StoryId).FirstOrDefault();

            if (storyJournalist != null)
            {
                throw new EntityAlreadyExistsException();
            }

            this.Context.StoryJournalist.Add(new StoryJournalist {
                JournalistId = request.JournalistId,
                StoryId = request.StoryId
            });

            this.Context.SaveChanges();
        }
    }
}
