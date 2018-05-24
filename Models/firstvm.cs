using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Plate.Models
{
    public class Personvm : BaseEntity
    {
        [Required]
        [MinLength(3)]
        public string First { get; set; }
        [Required]
        [MinLength(3)]
        public string Last { get; set; }
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [CompareAttribute("Password")]
        public string CPassword { get; set; }
    }
}