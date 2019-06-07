using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Searches;

namespace Application.Commands.Stories
{
    public interface IGetStoriesCommand : ICommand<StorySearch, IEnumerable<StoryDto>>
    {
    }
}
