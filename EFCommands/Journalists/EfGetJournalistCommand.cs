using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Journalists;
using Application.DataTransferObjects;
using Application.Exceptions;
using DataAccess;

namespace EFCommands.Journalists
{
    public class EfGetJournalistCommand : BaseEfCommand, IGetJournalistCommand
    {
        public EfGetJournalistCommand(Context context) : base(context)
        {
        }

        public JournalistDto Execute(int request)
        {
            var journalist = this.Context.Journalists.Find(request);

            if (journalist == null)
                throw new EntityNotFoundException("journalist");
            if (journalist.IsDeleted)
                throw new EntityNotFoundException("journalist");

            return new JournalistDto
            {
                Id = journalist.Id,
                FirstName = journalist.FirstName,
                LastName = journalist.LastName,
                IsActive = journalist.IsActive
            };
        }
    }
}
