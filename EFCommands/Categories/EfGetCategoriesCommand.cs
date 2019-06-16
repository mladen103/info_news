using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Categories;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;
using Application.Responses;
using Microsoft.EntityFrameworkCore;

namespace EFCommands.Categories
{
    public class EfGetCategoriesCommand : BaseEfCommand, IGetCategoriesCommand
    {
        public EfGetCategoriesCommand(Context context) : base(context)
        {
        }

        public PagedResponse<CategoryDto> Execute(CategorySearch request)
        {
            var query = this.Context.Categories
                .Include(c => c.Stories)
                .Where(c => !c.IsDeleted)
                .AsQueryable();

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

            int totalCount = query.Count();

            // number of pages/buttons
            int numberOfPages = (int)Math.Ceiling((double)totalCount / request.PerPage);

            query = query.Skip(request.PageNumber * request.PerPage - request.PerPage).Take(request.PerPage);
            // second way .Skip((request.PageNumber - 1)* request.PerPage).Take(request.PerPage);

            var result = new PagedResponse<CategoryDto> {
                TotalNumber = totalCount,
                PagesNumber = numberOfPages,
                CurrentPage = request.PageNumber,
                Data = query.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Stories = c.Stories.Select(s => new StoryDto {
                        Name = s.Name,
                        Description = s.Description,
                        Id = s.Id,
                        IsActive = s.IsActive
                   }),
                    IsActive = c.IsActive
               })
            };

            return result;
        }
    }
}
