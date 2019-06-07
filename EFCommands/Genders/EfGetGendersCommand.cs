using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Genders;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;

namespace EFCommands.Genders
{
    public class EfGetGendersCommand : BaseEfCommand, IGetGendersCommand
    {
        public EfGetGendersCommand(Context context) : base(context)
        {
        }

        public IEnumerable<GenderDto> Execute(GenderSearch request)
        {
            var query = this.Context.Genders.AsQueryable();

            if (request.Name != null)
            {
                query = query.Where(
                    g => g.Name.ToLower()
                    .Contains(request.Name.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    g => g.IsActive == request.IsActive);
            }

            return query.Select(g => new GenderDto
            {
                Id = g.Id,
                Name = g.Name
            });
        }
    }
}
