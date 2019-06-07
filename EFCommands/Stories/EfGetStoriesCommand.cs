using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Stories;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;

namespace EFCommands.Stories
{
    public class EfGetStoriesCommand : BaseEfCommand, IGetStoriesCommand
    {
        public EfGetStoriesCommand(Context context) : base(context)
        {
        }

        public IEnumerable<StoryDto> Execute(StorySearch request)
        {
            var query = this.Context.Stories.AsQueryable();

            if (request.Name != null)
            {
                query = query.Where(
                    s => s.Name.ToLower()
                    .Contains(request.Name.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    s => s.IsActive == request.IsActive);
            }

            if(request.Description != null)
            {
                query = query.Where(
                    s => s.Description.ToLower()
                    .Contains(request.Description.ToLower()));
            }
            
            return query.Select(s => new StoryDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            });
        }
    }
}
