using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Delete;
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

        }
    }
}
