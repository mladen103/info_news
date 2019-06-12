using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Logs;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;
using Application.Responses;

namespace EFCommands.Logs
{
    public class EfGetLogsCommand : BaseEfCommand, IGetLogsCommand
    {
        public EfGetLogsCommand(Context context) : base(context)
        {
        }

        public PagedResponse<LogDto> Execute(LogSearch request)
        {
            var query = this.Context.Logs
                .Where(l => !l.IsDeleted)
                .AsQueryable();

            if (request.Description != null)
            {
                query = query.Where(
                    l => l.Description.ToLower()
                    .Contains(request.Description.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    l => l.IsActive == request.IsActive);
            }

            int totalCount = query.Count();

            // number of pages/buttons
            int numberOfPages = (int)Math.Ceiling((double)totalCount / request.PerPage);

            query = query.Skip(request.PageNumber * request.PerPage - request.PerPage).Take(request.PerPage);
            // second way .Skip((request.PageNumber - 1)* request.PerPage).Take(request.PerPage);

            var result = new PagedResponse<LogDto>
            {
                TotalNumber = totalCount,
                PagesNumber = numberOfPages,
                CurrentPage = request.PageNumber,
                Data = query.Select(l => new LogDto
                {
                    Id = l.Id,
                    Description = l.Description
                })
            };

            return result;
        }
    }
}
