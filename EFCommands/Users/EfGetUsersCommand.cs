using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Users;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;

namespace EFCommands.Users
{
    public class EfGetUsersCommand : BaseEfCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(Context context) : base(context)
        {
        }

        public IEnumerable<UserGetDto> Execute(UserSearch request)
        {
            var query = this.Context.Users.AsQueryable();

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

            return query.Select(u => new UserGetDto
            {
                Id = u.Id,
                Email = u.Email,
                GenderId = u.GenderId,
                RoleId = u.RoleId
            });
        }
    }
}
