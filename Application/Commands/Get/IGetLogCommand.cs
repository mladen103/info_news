using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;

namespace Application.Commands.Get
{
    public interface IGetLogCommand : ICommand<int, LogDto>
    {
    }
}
