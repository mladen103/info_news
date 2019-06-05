using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Get;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;

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
                throw new EntityNotFoundException();
            if(category.IsDeleted == true)
                throw new EntityNotFoundException();

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
