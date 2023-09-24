using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserLearnedWordsRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int[]? WordIds { get; set; }
    }
}
