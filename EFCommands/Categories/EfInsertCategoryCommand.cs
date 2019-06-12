﻿using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Categories;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;

namespace EFCommands.Categories
{
    public class EfInsertCategoryCommand : BaseEfCommand, IInsertCategoryCommand
    {
        public EfInsertCategoryCommand(Context context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            if (this.Context.Genders
                .Where(g => !g.IsDeleted)
                .Any(c => c.Name == request.Name))
                throw new EntityAlreadyExistsException("category");

            this.Context.Add(new Category
            {
                Name = request.Name
            });

            this.Context.SaveChanges();
        }
    }
}
