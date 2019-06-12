using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Roles;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;

namespace EFCommands.Roles
{
    public class EfGetRoleCommand : BaseEfCommand, IGetRoleCommand
    {
        public EfGetRoleCommand(Context context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var role = this.Context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException("role");
            if (role.IsDeleted)
                throw new EntityNotFoundException("role");

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
