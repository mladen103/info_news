﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public abstract class BaseEfCommand
    {
        protected Context Context { get; }

        protected BaseEfCommand(Context context)
        {
            this.Context = context;
        }
    }
}
