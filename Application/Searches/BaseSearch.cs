using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public abstract class BaseSearch
    {
        public bool? IsActive { get; set; }
        public int PerPage { get; set; } = 6;
        public int PageNumber { get; set; } = 1;
    }
}
