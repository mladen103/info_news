using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Searches;
using Application.Responses;

namespace Application.Commands.Genders
{
    public interface IGetGendersCommand : ICommand<GenderSearch, PagedResponse<GenderDto>>
    {
    }
}
