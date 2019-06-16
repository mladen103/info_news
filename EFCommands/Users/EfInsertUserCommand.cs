using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Users;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;
using Application.Interfaces;

namespace EFCommands.Users
{
    public class EfInsertUserCommand : BaseEfCommand, IInsertUserCommand
    {
        private readonly IEmailSender emailSender;

        public EfInsertUserCommand(Context context, IEmailSender emailSender) : base(context)
        {
            this.emailSender = emailSender;
        }

        public void Execute(UserInsertDto request)
        {
            if (this.Context.Users
                .Where(g => !g.IsDeleted)
                .Any(u => u.Email == request.Email))
                throw new EntityAlreadyExistsException();

            if (!this.Context.Genders.Any(g => g.Id == request.GenderId))
            {
                throw new EntityNotFoundException("gender");
            }

            this.Context.Users.Add(new User
            {
                Email = request.Email,
                Password = request.Password,
                GenderId = request.GenderId,
                IsActive = request.IsActive,
                RoleId = request.RoleId
            });

            this.Context.SaveChanges();

            this.emailSender.Subject = "Info news";
            this.emailSender.Body = $"You have been added by administrator. Input parameters are <br/> Email: {request.Email} <br/>Password {request.Password}";
            this.emailSender.ToEmail = request.Email;
            this.emailSender.Send();
        }
    }
}
