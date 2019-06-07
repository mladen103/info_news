using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Genders;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;

namespace EFCommands.Genders
{
    public class EfInsertGenderCommand : BaseEfCommand, IInsertGenderCommand
    {
        public EfInsertGenderCommand(Context context) : base(context)
        {
        }

        public void Execute(GenderDto request)
        {
            var genders = this.Context.Genders;

            if (genders.Any(g => g.Name == request.Name))
                throw new EntityAlreadyExistsException();

            genders.Add(new Gender
            {
                Name = request.Name
            });

            this.Context.SaveChanges();
        }
    }
}
