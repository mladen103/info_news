using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class UserSearch : BaseSearch
    {
        public string Email { get; set; }
        public int? RoleId { get; set; }
    }
}
