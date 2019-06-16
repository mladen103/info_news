using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Roles;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;

namespace EFCommands.Roles
{
    public class EfInsertRoleCommand : BaseEfCommand, IInsertRoleCommand
    {
        public EfInsertRoleCommand(Context context) : base(context)
        {
        }

        public void Execute(RoleDto request)
        {
            if (this.Context.Roles
                .Where(g => !g.IsDeleted)
                .Any(r => r.Name == request.Name))
                throw new EntityAlreadyExistsException();

            this.Context.Roles.Add(new Role
            {
                Name = request.Name,
                IsActive = request.IsActive
            });

            this.Context.SaveChanges();
        }
    }
}
