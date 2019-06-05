using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Get;
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
                throw new EntityNotFoundException();
            if (journalist.IsDeleted == true)
                throw new EntityNotFoundException();

            return new JournalistDto
            {
                Id = journalist.Id,
                FirstName = journalist.FirstName,
                LastName = journalist.LastName
            };
        }
    }
}
