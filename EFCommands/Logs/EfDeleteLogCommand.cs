using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Delete;
using Application.Exceptions;
using DataAccess;

namespace EFCommands
{
    public class EfDeleteLogCommand : BaseEfCommand, IDelete
    {
        public EfDeleteLogCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var log = this.Context.Logs.Find(request);

            if (log == null)
                throw new EntityNotFoundException();

            log.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
