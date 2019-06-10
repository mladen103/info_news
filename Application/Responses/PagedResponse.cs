using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class PagedResponse<T>
    {
        public int TotalNumber { get; set; }
        public int PagesNumber { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
