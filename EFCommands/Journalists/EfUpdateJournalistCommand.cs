using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Application.Commands.Journalists;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;
using Domain;

namespace EFCommands.Journalists
{
    public class EfUpdateJournalistCommand : BaseEfCommand, IUpdateJournalistCommand
    {
        public EfUpdateJournalistCommand(Context context) : base(context)
        {
        }

        public void Execute(JournalistDto request)
        {
            var journalist = this.Context.Journalists.Find(request.Id);
            if (journalist == null)
                throw new EntityNotFoundException("journalist");
            if (journalist.IsDeleted)
                throw new EntityNotFoundException("journalist");
            
            if (journalist.FirstName != request.FirstName)
                journalist.FirstName = request.FirstName;
            if (journalist.LastName != request.LastName)
                journalist.LastName = request.LastName;
            if (journalist.IsActive != request.IsActive)
                journalist.IsActive = request.IsActive;

            journalist.ModifiedAt = DateTime.Now;

            this.Context.SaveChanges();
        }
    }
}
