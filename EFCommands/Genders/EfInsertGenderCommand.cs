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
            
            if (this.Context.Genders
                .Where(g => !g.IsDeleted)
                .Any(g => g.Name == request.Name))
                throw new EntityAlreadyExistsException("gender");

            this.Context.Genders.Add(new Gender
            {
                Name = request.Name
            });

            this.Context.SaveChanges();
        }
    }
}
