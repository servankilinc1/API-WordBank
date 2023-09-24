using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ViewModelWord
    {
        public Word? Word { get; set; }
        public bool IsUeserAddedFav { get; set; }
    }
}
