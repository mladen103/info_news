using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Application.Commands.Logs;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EFCommands.Logs
{
    public class EfUpdateLogCommand : BaseEfCommand, IUpdateLogCommand
    {
        public EfUpdateLogCommand(Context context) : base(context)
        {
        }

        public void Execute(LogDto request)
        {
            var log = this.Context.Logs.Find(request.Id);
            if (log == null)
                throw new EntityNotFoundException();

            var logs = this.Context.Logs;

            if (log.Description != request.Description)
                log.Description = request.Description;

            this.Context.SaveChanges();
        }
    }
}
