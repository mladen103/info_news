using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;

namespace EFCommands.Stories
{
    public class EfGetStoriesCommand : BaseEfCommand, IGetStoriesCommand
    {
        public EfGetStoriesCommand(Context context) : base(context)
        {
        }

        public IEnumerable<StoryDto> Execute(CategorySearch request)
        {
            var query = this.Context.Stories.AsQueryable();

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

            return query.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
