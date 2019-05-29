using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Picture : BaseEntity
    {
        public string Name { get; set; } // this will be and alt attribute
        public string Path { get; set; }
        public int StoryId { get; set; }

        public Story Story { get; set; }
    }
}
