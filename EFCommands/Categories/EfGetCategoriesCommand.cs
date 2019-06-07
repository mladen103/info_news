using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Categories;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;

namespace EFCommands.Categories
{
    public class EfGetCategoriesCommand : BaseEfCommand, IGetCategoriesCommand
    {
        public EfGetCategoriesCommand(Context context) : base(context)
        {
        }

        public IEnumerable<CategoryDto> Execute(CategorySearch request)
        {
            var query = this.Context.Categories.AsQueryable();

            if (request.Name != null)
            {
                query = query.Where(
                    c => c.Name.ToLower()
                    .Contains(request.Name.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    c => c.IsActive == request.IsActive);
            }

            return query.Select(c => new CategoryDto {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
