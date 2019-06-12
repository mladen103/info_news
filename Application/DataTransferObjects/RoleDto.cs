using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class RoleDto : BaseDto
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(4, ErrorMessage = "Role name must have at least 4 characters.")]
        public string Name { get; set; }
    }
}
