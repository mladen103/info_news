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
            this.emailSender.Body = $"Dodati ste od strane administratora. Ulazni parametri su <br/> Email: {request.Email} <br/>Lozinka {request.Password}";
            this.emailSender.ToEmail = "djomla544@gmail.com";
            this.emailSender.Send();
        }
    }
}
