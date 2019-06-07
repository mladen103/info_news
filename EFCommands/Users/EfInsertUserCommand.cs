using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Users;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;

namespace EFCommands.Users
{
    public class EfInsertUserCommand : BaseEfCommand, IInsertUserCommand
    {
        public EfInsertUserCommand(Context context) : base(context)
        {
        }

        public void Execute(UserInsertDto request)
        {
            var users = this.Context.Users;

            if (users.Any(u => u.Email == request.Email))
                throw new EntityAlreadyExistsException();

            users.Add(new User
            {
                Email = request.Email,
                Password = request.Password
            });

            this.Context.SaveChanges();
        }
    }
}
