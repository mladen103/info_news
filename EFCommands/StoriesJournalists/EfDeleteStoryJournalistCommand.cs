using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Application.Commands.StoriesJournalists;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;

namespace EFCommands.StoriesJournalists
{
    public class EfDeleteStoryJournalistCommand : BaseEfCommand, IDeleteStoryJournalistCommand
    {
        public EfDeleteStoryJournalistCommand(Context context) : base(context)
        {
        }

        public void Execute(StoryJournalistDto request)
        {
            var storyJournalist = this.Context.StoryJournalist.Where(sj => sj.JournalistId == request.JournalistId && sj.StoryId == request.StoryId).FirstOrDefault();

            if(storyJournalist == null)
            {
                throw new EntityNotFoundException();
            }

            this.Context.StoryJournalist.Remove(storyJournalist);
            this.Context.SaveChanges();
        }
    }
}
