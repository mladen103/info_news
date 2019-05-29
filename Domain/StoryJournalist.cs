using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class StoryJournalist
    {
        public int StoryId { get; set; }
        public int JournalistId { get; set; }

        public Story Story { get; set; }
        public Journalist Journalist { get; set; }
    }
}
