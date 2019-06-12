using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class UserGetDto : BaseDto
    {
        [EmailAddress(ErrorMessage = "Email has invalid format.")]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int GenderId { get; set; }
    }
}
