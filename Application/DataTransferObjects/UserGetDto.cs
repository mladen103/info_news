using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransferObjects
{
    public class UserGetDto : BaseDto
    {
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int GenderId { get; set; }
    }
}
