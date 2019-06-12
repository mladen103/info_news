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
            if (this.Context.Users
                .Where(g => !g.IsDeleted)
                .Any(u => u.Email == request.Email))
                throw new EntityAlreadyExistsException();

            this.Context.Users.Add(new User
            {
                Email = request.Email,
                Password = request.Password
            });

            this.Context.SaveChanges();
        }
    }
}
