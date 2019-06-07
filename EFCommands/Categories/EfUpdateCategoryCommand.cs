using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Application.Commands.Categories;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EFCommands.Categories
{
    public class EfUpdateCategoryCommand : BaseEfCommand, IUpdateCategoryCommand
    {
        public EfUpdateCategoryCommand(Context context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            var category = this.Context.Categories.Find(request.Id);
            if (category == null)
                throw new EntityNotFoundException();

            var categories = this.Context.Categories;

            if(category.Name != request.Name)
                if (categories.Any(c => c.Name == request.Name))
                    throw new EntityAlreadyExistsException();
            
            category.Name = request.Name;

            this.Context.SaveChanges();
        }
    }
}
