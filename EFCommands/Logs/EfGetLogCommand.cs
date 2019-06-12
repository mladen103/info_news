using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Logs;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;

namespace EFCommands.Logs
{
    public class EfGetLogCommand : BaseEfCommand, IGetLogCommand
    {
        public EfGetLogCommand(Context context) : base(context)
        {
        }

        public LogDto Execute(int request)
        {
            var log = this.Context.Logs.Find(request);

            if (log == null)
                throw new EntityNotFoundException("log");
            if (log.IsDeleted)
                throw new EntityNotFoundException("log");

            return new LogDto
            {
                Id = log.Id,
                Description = log.Description
            };
        }
    }
}
