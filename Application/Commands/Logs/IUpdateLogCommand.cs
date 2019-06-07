using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;

namespace Application.Commands.Logs
{
    public interface IUpdateLogCommand : ICommand<LogDto>
    {
    }
}
