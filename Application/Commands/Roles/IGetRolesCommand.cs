using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Searches;
using Application.Responses;

namespace Application.Commands.Roles
{
    public interface IGetRolesCommand : ICommand<RoleSearch, PagedResponse<RoleDto>>
    {
    }
}
