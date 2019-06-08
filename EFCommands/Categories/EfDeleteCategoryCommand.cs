using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Categories;
using DataAccess;
using Application.Exceptions;
using Domain;

namespace EFCommands
{
    public class EfDeleteCategoryCommand : BaseEfCommand, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var category = this.Context.Categories.Find(request);

            if (category == null)
                throw new EntityNotFoundException();

            category.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
