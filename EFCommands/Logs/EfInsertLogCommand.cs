using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Logs;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;

namespace EFCommands.Logs
{
    public class EfInsertLogCommand : BaseEfCommand, IInsertLogCommand
    {
        public EfInsertLogCommand(Context context) : base(context)
        {
        }

        public void Execute(LogDto request)
        {
            var logs = this.Context.Logs;
            
            logs.Add(new Log
            {
                Description = request.Description
            });

            this.Context.SaveChanges();
        }
    }
}
