using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Dtos
{
    public class BookCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
