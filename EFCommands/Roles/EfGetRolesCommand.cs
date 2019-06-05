using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;

namespace EFCommands.Roles
{
    public class EfGetRolesCommand : BaseEfCommand, IGetRolesCommand
    {
        public EfGetRolesCommand(Context context) : base(context)
        {
        }

        public IEnumerable<RoleDto> Execute(RoleSearch request)
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

            return query.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            });
        }
    }
}
