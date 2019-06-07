using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Application.Commands.Users;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EFCommands.Users
{
    public class EfUpdateUserCommand : BaseEfCommand, IUpdateUserCommand
    {
        public EfUpdateUserCommand(Context context) : base(context)
        {
        }

        public void Execute(UserInsertDto request)
        {
            var user = this.Context.Users.Find(request.Id);
            if (user == null)
                throw new EntityNotFoundException();

            var users = this.Context.Users;

            
            if (user.Email != request.Email)
            {
                if (users.Any(u => u.Email == request.Email))
                    throw new EntityAlreadyExistsException();
                else
                    user.Email = request.Email;
            }

            if (user.Password != request.Password)
                user.Password = request.Password;
            
            this.Context.SaveChanges();
        }
    }
}
