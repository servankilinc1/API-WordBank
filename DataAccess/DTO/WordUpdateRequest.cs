using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class WordUpdateRequest
    {
        [Required]
        public int Id{ get; set; }
        [Required]
        public string? Turkish { get; set; }
        [Required]
        public string? English { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
