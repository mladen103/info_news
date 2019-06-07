using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Application.Commands.Genders;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EFCommands.Genders
{
    public class EfUpdateGenderCommand : BaseEfCommand, IUpdateGenderCommand
    {
        public EfUpdateGenderCommand(Context context) : base(context)
        {
        }

        public void Execute(GenderDto request)
        {
            var gender = this.Context.Genders.Find(request.Id);
            if (gender == null)
                throw new EntityNotFoundException();

            var genders = this.Context.Categories;

            if (gender.Name != request.Name)
                if (genders.Any(g => g.Name == request.Name))
                    throw new EntityAlreadyExistsException();

            gender.Name = request.Name;

            this.Context.SaveChanges();
        }
    }
}
