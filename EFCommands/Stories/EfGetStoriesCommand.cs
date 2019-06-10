using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Stories;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;
using Application.Responses;

namespace EFCommands.Stories
{
    public class EfGetStoriesCommand : BaseEfCommand, IGetStoriesCommand
    {
        public EfGetStoriesCommand(Context context) : base(context)
        {
        }

        public PagedResponse<StoryDto> Execute(StorySearch request)
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

            int totalCount = query.Count();

            // number of pages/buttons
            int numberOfPages = (int)Math.Ceiling((double)totalCount / request.PerPage);

            query = query.Skip(request.PageNumber * request.PerPage - request.PerPage).Take(request.PerPage);
            // second way .Skip((request.PageNumber - 1)* request.PerPage).Take(request.PerPage);

            var result = new PagedResponse<StoryDto>
            {
                TotalNumber = totalCount,
                PagesNumber = numberOfPages,
                CurrentPage = request.PageNumber,
                Data = query.Select(s => new StoryDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                })
            };

            return result;
            
        }
    }
}
