using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ViewModelCategory
    {
        public Category? Category { get; set; }
        public int TotalWordCount { get; set; } = 0;
        public int LearnedWordCount { get; set; } = 0;
    }
}
