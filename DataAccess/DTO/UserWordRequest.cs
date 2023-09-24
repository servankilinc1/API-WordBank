using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserWordRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int WordId { get; set; }
    }
}
