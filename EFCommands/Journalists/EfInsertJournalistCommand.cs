using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Journalists;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;

namespace EFCommands.Journalists
{
    public class EfInsertJournalistCommand : BaseEfCommand, IInsertJournalistCommand
    {
        public EfInsertJournalistCommand(Context context) : base(context)
        {
        }

        public void Execute(JournalistDto request)
        {
            this.Context.Journalists.Add(new Journalist
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IsActive = request.IsActive
            });

            this.Context.SaveChanges();
        }
    }
}
