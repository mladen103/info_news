﻿using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class UserInsertDto
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email has invalid format.")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters.")]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
