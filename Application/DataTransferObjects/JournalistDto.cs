using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class JournalistDto : BaseDto
    {
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("^[A-Z][a-z]{2,18}$", ErrorMessage = "First name for journalist isn't in right format.")]
        public string FirstName { get; set; }
        [RegularExpression("^[A-Z][a-z]{2,18}$", ErrorMessage = "Last name for journalist isn't in right format.")]
        public string LastName { get; set; }
    }
}
