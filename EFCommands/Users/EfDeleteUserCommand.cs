using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Users;
using Application.Exceptions;
using DataAccess;

namespace EFCommands
{
    public class EfDeleteUserCommand : BaseEfCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var user = this.Context.Users.Find(request);

            if (user == null)
                throw new EntityNotFoundException("user");
            if (user.IsDeleted)
                throw new EntityNotFoundException("user");


            user.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
