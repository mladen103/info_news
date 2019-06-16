using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class StoryInsertDto
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(6, ErrorMessage = "Story name must have at least 6 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(20, ErrorMessage = "Story description must have at least 20 characters.")]
        public string Description { get; set; }
        [Required]
        public IFormFile Picture { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public IEnumerable<int> Journalists { get; set; }
    }
}
