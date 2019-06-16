using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Pictures;
using Application.DataTransferObjects;
using DataAccess;
using Domain;
using System.Linq;
using Application.Exceptions;

namespace EFCommands.Pictures
{
    public class EfInsertPictureCommand : BaseEfCommand, IInsertPictureCommand
    {
        public EfInsertPictureCommand(Context context) : base(context)
        {
        }

        public void Execute(PictureDto request)
        {
            this.Context.Pictures.Add(new Picture
            {
                Name = request.Name,
                Path = request.Path
            });

            this.Context.SaveChanges();
        }
    }
}
