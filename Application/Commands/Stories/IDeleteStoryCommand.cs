using System;
using System.Collections.Generic;
using System.Text;

using Application.Interfaces;

namespace Application.Commands.Stories
{
    public interface IDeleteStoryCommand : ICommand<int>
    {
    }
}
