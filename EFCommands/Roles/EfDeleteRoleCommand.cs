using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Delete;
using Application.Exceptions;
using DataAccess;

namespace EFCommands
{
    public class EfDeleteRoleCommand : BaseEfCommand, IDelete
    {
        public EfDeleteRoleCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var role = this.Context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException();

            role.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
