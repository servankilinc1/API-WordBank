using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Category
    {
        [Key]
        public int Id{ get; set; }
        public string? Turkish{ get; set; }
        public string? English{ get; set; }
        public string? Image { get; set; }
        public ICollection<Word>? Words{ get; set; }
    }
}