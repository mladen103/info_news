using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int GenderId { get; set; }

        public Role Role { get; set; }
        public Gender Gender { get; set; }
    }
}
