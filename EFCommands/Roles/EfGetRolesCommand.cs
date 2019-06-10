using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Roles;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;
using Application.Responses;

namespace EFCommands.Roles
{
    public class EfGetRolesCommand : BaseEfCommand, IGetRolesCommand
    {
        public EfGetRolesCommand(Context context) : base(context)
        {
        }

        public PagedResponse<RoleDto> Execute(RoleSearch request)
        {
            var query = this.Context.Roles.AsQueryable();

            if (request.Name != null)
            {
                query = query.Where(
                    r => r.Name.ToLower()
                    .Contains(request.Name.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    r => r.IsActive == request.IsActive);
            }

            int totalCount = query.Count();

            // number of pages/buttons
            int numberOfPages = (int)Math.Ceiling((double)totalCount / request.PerPage);

            query = query.Skip(request.PageNumber * request.PerPage - request.PerPage).Take(request.PerPage);
            // second way .Skip((request.PageNumber - 1)* request.PerPage).Take(request.PerPage);

            var result = new PagedResponse<RoleDto>
            {
                TotalNumber = totalCount,
                PagesNumber = numberOfPages,
                CurrentPage = request.PageNumber,
                Data = query.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name
                })
            };

            return result;
            
        }
    }
}
