using System;
using System.Collections.Generic;
using System.Text;

using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Searches;
using Application.Responses;

namespace Application.Commands.Stories
{
    public interface IGetStoriesCommand : ICommand<StorySearch, PagedResponse<StoryDto>>
    {
    }
}
