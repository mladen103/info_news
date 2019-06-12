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
                throw new EntityNotFoundException("category");
            if(category.IsDeleted)
                throw new EntityNotFoundException("category");
            
            if(category.Name != request.Name)
                if (this.Context.Categories.Any(c => c.Name == request.Name))
                    throw new EntityAlreadyExistsException("category");
            
            category.Name = request.Name;

            this.Context.SaveChanges();
        }
    }
}
