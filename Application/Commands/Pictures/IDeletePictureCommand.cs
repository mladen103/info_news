using System;
using System.Collections.Generic;
using System.Text;

using Application.Interfaces;

namespace Application.Commands.Pictures
{
    public interface IDeletePictureCommand : ICommand<int>
    {
    }
}
