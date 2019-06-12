using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class StoryDto : BaseDto
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(6, ErrorMessage = "Story name must have at least 6 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(20, ErrorMessage = "Story description must have at least 20 characters.")]
        public string Description { get; set; }

        public ICollection<JournalistDto> Journalists { get; set; }
    }
}
