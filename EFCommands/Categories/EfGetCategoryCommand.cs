using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Categories;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using System.Linq;

namespace EFCommands.Categories
{
    public class EfGetCategoryCommand : BaseEfCommand, IGetCategoryCommand
    {
        public EfGetCategoryCommand(Context context) : base(context)
        {
        }

        public CategoryDto Execute(int request)
        {
            var category = this.Context.Categories.Find(request);

            if (category == null)
                throw new EntityNotFoundException("category");
            if(category.IsDeleted)
                throw new EntityNotFoundException("category");

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
