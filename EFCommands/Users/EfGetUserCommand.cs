using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Users;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;

namespace EFCommands.Users
{
    public class EfGetUserCommand : BaseEfCommand, IGetUserCommand
    {
        public EfGetUserCommand(Context context) : base(context)
        {
        }

        public UserGetDto Execute(int request)
        {
            var user = this.Context.Users.Find(request);

            if (user == null)
                throw new EntityNotFoundException("user");
            if (user.IsDeleted)
                throw new EntityNotFoundException("user");

            return new UserGetDto
            {
                Id = user.Id,
                Email = user.Email,
                GenderId = user.GenderId,
                RoleId = user.RoleId
            };
        }
    }
}
