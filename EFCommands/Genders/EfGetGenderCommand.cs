using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Genders;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;

namespace EFCommands.Genders
{
    public class EfGetGenderCommand : BaseEfCommand, IGetGenderCommand
    {
        public EfGetGenderCommand(Context context) : base(context)
        {
        }

        public GenderDto Execute(int request)
        {
            var gender = this.Context.Genders.Find(request);

            if (gender == null)
                throw new EntityNotFoundException("gender");
            if (gender.IsDeleted)
                throw new EntityNotFoundException("gender");

            return new GenderDto
            {
                Id = gender.Id,
                Name = gender.Name
            };
        }
    }
}
