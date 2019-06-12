using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Application.Commands.Roles;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EFCommands.Roles
{
    public class EfUpdateRoleCommand : BaseEfCommand, IUpdateRoleCommand
    {
        public EfUpdateRoleCommand(Context context) : base(context)
        {
        }

        public void Execute(RoleDto request)
        {
            var role = this.Context.Roles.Find(request.Id);
            if (role == null)
                throw new EntityNotFoundException("role");
            if (role.IsDeleted)
                throw new EntityNotFoundException("role");
            
            if (role.Name != request.Name)
                if (this.Context.Roles.Any(r => r.Name == request.Name))
                    throw new EntityAlreadyExistsException("role");
            role.Name = request.Name;

            if (role.IsActive != request.IsActive)
                role.IsActive = request.IsActive;

            role.ModifiedAt = DateTime.Now;

            this.Context.SaveChanges();
        }
    }
}
