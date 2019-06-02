using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferObjects
{
    public class UserInsertDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int GenderId { get; set; }
    }
}
