using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class WordResponse
    {
        public int Id { get; set; }
        public string? Turkish { get; set; }
        public string? English { get; set; }
        public string? Image { get; set; }
    }
}
