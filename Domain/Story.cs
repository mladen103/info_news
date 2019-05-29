using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Story : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<StoryJournalist> StoryJournalists { get; set; }
    }
}
