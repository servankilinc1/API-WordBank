using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utils
{
    public class DataResultSuccess<T> : IDataResult<T>
    {
        public DataResultSuccess(T _data, string _message)
        {
            Data = _data;
            Message = _message;
            Success = true;
        }
        public DataResultSuccess(T _data)
        {
            Data = _data;
            Success = true;
        }

        public T? Data { get; set; }
        public string? Message { get ; set ; }
        public bool Success { get ; set ; }
    }
}
