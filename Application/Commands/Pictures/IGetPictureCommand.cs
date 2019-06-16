using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;

namespace Application.Commands.Pictures
{
    public interface IGetPictureCommand : ICommand<int, PictureDto>
    {
    }
}
