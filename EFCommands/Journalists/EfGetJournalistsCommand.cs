using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Journalists;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;

namespace EFCommands.Journalists
{
    public class EfGetJournalistsCommand : BaseEfCommand, IGetJournalistsCommand
    {
        public EfGetJournalistsCommand(Context context) : base(context)
        {
        }

        public IEnumerable<JournalistDto> Execute(JournalistSearch request)
        {
            var query = this.Context.Journalists.Where(j => !j.IsDeleted).AsQueryable();

            if (request.FirstName != null)
            {
                query = query.Where(
                    j => j.FirstName.ToLower()
                    .Contains(request.FirstName.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    j => j.IsActive == request.IsActive);
            }

            


            return query.Select(j => new JournalistDto
            {
                Id = j.Id,
                FirstName = j.FirstName,
                LastName = j.LastName
            });
        }
    }
}
