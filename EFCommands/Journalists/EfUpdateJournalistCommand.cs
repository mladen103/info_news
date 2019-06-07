﻿using System;
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
                throw new EntityNotFoundException();

            var journalists = this.Context.Journalists;

            if (journalist.FirstName != request.FirstName)
                journalist.FirstName = request.FirstName;
            if (journalist.LastName != request.LastName)
                journalist.LastName = request.LastName;


            this.Context.SaveChanges();
        }
    }
}