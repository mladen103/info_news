using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;

namespace Application.Commands.Genders
{
    public interface IGetGenderCommand : ICommand<int, GenderDto>
    {
    }
}
