using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Searches;

namespace Application.Commands.Roles
{
    public interface IGetRolesCommand : ICommand<RoleSearch, IEnumerable<RoleDto>>
    {
    }
}
