using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Delete;
using DataAccess;

namespace EFCommands
{
    public class EfDeleteGenderCommand : BaseEfCommand, IDelete
    {
        public EfDeleteGenderCommand(Context context) : base(context)
        {

        }

        public void Execute(int request)
        {
            
        }
    }
}
