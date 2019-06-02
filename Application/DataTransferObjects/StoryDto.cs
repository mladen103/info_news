using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferObjects
{
    public class StoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
