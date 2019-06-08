using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Journalists;
using DataAccess;
using Application.Exceptions;
using Domain;

namespace EFCommands
{
    public class EfDeleteJournalistCommand : BaseEfCommand, IDeleteJournalistCommand
    {
        public EfDeleteJournalistCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var journalist = this.Context.Journalists.Find(request);

            if (journalist == null)
                throw new EntityNotFoundException();

            journalist.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}
