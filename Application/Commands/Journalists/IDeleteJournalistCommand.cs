using System;
using System.Collections.Generic;
using System.Text;

using Application.Interfaces;

namespace Application.Commands.Journalists
{
    public interface IDeleteJournalistCommand : ICommand<int>
    {
    }
}
