﻿using System;
using System.Collections.Generic;
using System.Text;

using Application.Interfaces;

namespace Application.Commands.Categories
{
    public interface IDeleteCategoryCommand : ICommand<int>
    {
    }
}
