using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public abstract class BaseDto
    {
        public int Id { get; set; }

//        [Required(ErrorMessage = "This field is required.")]
        public bool IsActive { get; set; } = true;
    }
}
