﻿using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Delete;
using Application.Exceptions;
using DataAccess;

namespace EFCommands
{
    public class EfDeleteGenderCommand : BaseEfCommand, IDelete
    {
        public EfDeleteGenderCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var gender = this.Context.Genders.Find(request);

            if (gender == null)
                throw new EntityNotFoundException();

            gender.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}