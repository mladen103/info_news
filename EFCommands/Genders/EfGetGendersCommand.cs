using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Genders;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;
using Application.Responses;

namespace EFCommands.Genders
{
    public class EfGetGendersCommand : BaseEfCommand, IGetGendersCommand
    {
        public EfGetGendersCommand(Context context) : base(context)
        {
        }

        public PagedResponse<GenderDto> Execute(GenderSearch request)
        {
            var query = this.Context.Genders.AsQueryable();

            if (request.Name != null)
            {
                query = query.Where(
                    g => g.Name.ToLower()
                    .Contains(request.Name.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    g => g.IsActive == request.IsActive);
            }
            
            int totalCount = query.Count();

            // number of pages/buttons
            int numberOfPages = (int)Math.Ceiling((double)totalCount / request.PerPage);

            query = query.Skip(request.PageNumber * request.PerPage - request.PerPage).Take(request.PerPage);
            // second way .Skip((request.PageNumber - 1)* request.PerPage).Take(request.PerPage);

            var result = new PagedResponse<GenderDto>
            {
                TotalNumber = totalCount,
                PagesNumber = numberOfPages,
                CurrentPage = request.PageNumber,
                Data = query.Select(g => new GenderDto
                {
                    Id = g.Id,
                    Name = g.Name
                })
            };

            return result;
        }
    }
}
