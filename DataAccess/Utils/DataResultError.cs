using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utils
{
    public class DataResultError<T>:IDataResult<T>
    {
        public DataResultError(string _message)
        {
            Data = default;
            Message = _message;
            Success = false;
        }
        public DataResultError()
        {
            Data = default;
            Success = false;
        }


        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
