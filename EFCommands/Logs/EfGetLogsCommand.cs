using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Application.Commands.Logs;
using Application.DataTransferObjects;
using Application.Searches;
using DataAccess;

namespace EFCommands.Logs
{
    public class EfGetLogsCommand : BaseEfCommand, IGetLogsCommand
    {
        public EfGetLogsCommand(Context context) : base(context)
        {
        }

        public IEnumerable<LogDto> Execute(LogSearch request)
        {
            var query = this.Context.Logs.AsQueryable();

            if (request.Description != null)
            {
                query = query.Where(
                    l => l.Description.ToLower()
                    .Contains(request.Description.ToLower()));
            }

            if (request.IsActive != null)
            {
                query = query.Where(
                    l => l.IsActive == request.IsActive);
            }

            return query.Select(l => new LogDto
            {
                Id = l.Id,
                Description = l.Description
            });
        }
    }
}
