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
            var story = this.Context.Users.Find(request);

            if (story == null)
                throw new EntityNotFoundException();

            story.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
