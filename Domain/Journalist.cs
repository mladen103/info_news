using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Journalist : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<StoryJournalist> JournalistStories { get; set; }
    }
}
