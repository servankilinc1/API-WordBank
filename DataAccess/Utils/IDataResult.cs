using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utils
{
    public interface IDataResult<out T>
    {
        public T? Data { get; }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
