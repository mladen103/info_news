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
                throw new EntityNotFoundException("gender");
            if (gender.IsDeleted)
                throw new EntityNotFoundException("gender");
            
            if (gender.Name != request.Name)
                if (this.Context.Genders.Any(g => g.Name == request.Name))
                    throw new EntityAlreadyExistsException("gender");
                gender.Name = request.Name;

            if(gender.IsActive != request.IsActive)
                gender.IsActive = request.IsActive;

            gender.ModifiedAt = DateTime.Now;

            this.Context.SaveChanges();
        }
    }
}
