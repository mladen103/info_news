using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Journalists;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;
using Application.Responses;

namespace EFCommands.Journalists
{
    public class EfGetJournalistsCommand : BaseEfCommand, IGetJournalistsCommand
    {
        public EfGetJournalistsCommand(Context context) : base(context)
        {
        }

        public PagedResponse<JournalistDto> Execute(JournalistSearch request)
        {
            var query = this.Context.Journalists
                .Where(j => !j.IsDeleted)
                .AsQueryable();

            if (request.FirstName != null)
            {
                query = query.Where(
                    j => j.FirstName.ToLower()
                    .Contains(request.FirstName.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    j => j.IsActive == request.IsActive);
            }

            int totalCount = query.Count();

            // number of pages/buttons
            int numberOfPages = (int)Math.Ceiling((double)totalCount / request.PerPage);

            query = query.Skip(request.PageNumber * request.PerPage - request.PerPage).Take(request.PerPage);
            // second way .Skip((request.PageNumber - 1)* request.PerPage).Take(request.PerPage);

            var result = new PagedResponse<JournalistDto>
            {
                TotalNumber = totalCount,
                PagesNumber = numberOfPages,
                CurrentPage = request.PageNumber,
                Data = query.Select(j => new JournalistDto
                {
                    Id = j.Id,
                    FirstName = j.FirstName,
                    LastName = j.LastName,
                    IsActive = j.IsActive
                })
            };

            return result;
            
        }
    }
}
