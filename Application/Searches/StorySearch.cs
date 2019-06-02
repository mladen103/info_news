using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class StorySearch : BaseSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
