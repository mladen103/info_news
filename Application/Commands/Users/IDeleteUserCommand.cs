using System;
using System.Collections.Generic;
using System.Text;

using Application.Interfaces;

namespace Application.Commands.Users
{
    public interface IDeleteUserCommand : ICommand<int>
    {
    }
}
