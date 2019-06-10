using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Searches;
using Application.Responses;

namespace Application.Commands.Users
{
    public interface IGetUsersCommand : ICommand<UserSearch, PagedResponse<UserGetDto>>
    {
    }
}
