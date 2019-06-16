using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Users;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;
using Application.Responses;

namespace EFCommands.Users
{
    public class EfGetUsersCommand : BaseEfCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(Context context) : base(context)
        {
        }

        public PagedResponse<UserGetDto> Execute(UserSearch request)
        {
            var query = this.Context.Users
                .Where(u => !u.IsDeleted)
                .AsQueryable();
            
            if (request.Email != null)
            {
                query = query.Where(
                    u => u.Email.ToLower()
                    .Contains(request.Email.ToLower()));
            }

            if (request.RoleId != null)
            {
                query = query.Where(
                    u => u.Email.ToLower()
                    .Contains(request.Email.ToLower()));
            }
            
            if (request.IsActive != null)
            {
                query = query.Where(
                    u => u.IsActive == request.IsActive);
            }

            int totalCount = query.Count();

            // number of pages/buttons
            int numberOfPages = (int)Math.Ceiling((double)totalCount / request.PerPage);

            query = query.Skip(request.PageNumber * request.PerPage - request.PerPage).Take(request.PerPage);
            // second way .Skip((request.PageNumber - 1)* request.PerPage).Take(request.PerPage);

            var result = new PagedResponse<UserGetDto>
            {
                TotalNumber = totalCount,
                PagesNumber = numberOfPages,
                CurrentPage = request.PageNumber,
                Data = query.Select(u => new UserGetDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    GenderId = u.GenderId,
                    RoleId = u.RoleId,
                    IsActive = u.IsActive
                })
            };

            return result;
            
        }
    }
}
