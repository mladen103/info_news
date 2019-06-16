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
            
            this.Context.Stories.Add(new Story
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = request.IsActive,
                Picture = request.Picture
            });

            this.Context.SaveChanges();
        }
    }
}
