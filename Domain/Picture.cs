using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Picture : BaseEntity
    {
        public string Name { get; set; } // this will be an alt attribute
        public string Path { get; set; }

        public Story Story { get; set; }
    }
}
