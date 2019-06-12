using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Roles;
using Application.Exceptions;
using DataAccess;

namespace EFCommands
{
    public class EfDeleteRoleCommand : BaseEfCommand, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var role = this.Context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException("role");
            if (role.IsDeleted)
                throw new EntityNotFoundException("role");

            role.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
