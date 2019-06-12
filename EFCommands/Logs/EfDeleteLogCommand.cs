using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Logs;
using Application.Exceptions;
using DataAccess;

namespace EFCommands
{
    public class EfDeleteLogCommand : BaseEfCommand, IDeleteLogCommand
    {
        public EfDeleteLogCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var log = this.Context.Logs.Find(request);

            if (log == null)
                throw new EntityNotFoundException("log");
            if (log.IsDeleted)
                throw new EntityNotFoundException("log");

            log.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
