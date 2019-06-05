﻿using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Delete;
using Application.Exceptions;
using DataAccess;

namespace EFCommands
{
    public class EfDeleteStoryCommand : BaseEfCommand, IDelete
    {
        public EfDeleteStoryCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            var story = this.Context.Stories.Find(request);

            if (story == null)
                throw new EntityNotFoundException();

            story.IsDeleted = true;
            this.Context.SaveChanges();
        }
    }
}