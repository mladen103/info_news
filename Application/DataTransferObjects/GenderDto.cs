using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class GenderDto : BaseDto
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(4, ErrorMessage = "Gender name must have at least 3 characters.")]
        public string Name { get; set; }
    }
}
