using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;

namespace Application.Commands.Genders
{
    public interface IUpdateGenderCommand : ICommand<GenderDto>
    {
    }
}
