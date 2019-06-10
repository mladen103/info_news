using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Searches;
using Application.Responses;

namespace Application.Commands.Logs
{
    public interface IGetLogsCommand : ICommand<LogSearch, PagedResponse<LogDto>>
    {
    }
}
