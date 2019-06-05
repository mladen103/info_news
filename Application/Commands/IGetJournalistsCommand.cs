﻿using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Searches;

namespace Application.Commands
{
    public interface IGetJournalistsCommand : ICommand<JournalistSearch, IEnumerable<JournalistDto>>
    {
    }
}
