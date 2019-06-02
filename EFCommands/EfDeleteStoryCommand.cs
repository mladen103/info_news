using System;
using System.Collections.Generic;
using System.Text;

using Application.Commands.Delete;
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

        }
    }
}
