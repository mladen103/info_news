using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class LogDto : BaseDto
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(10, ErrorMessage = "Log description must have at least 10 characters.")]
        public string Description { get; set; }
    }
}
