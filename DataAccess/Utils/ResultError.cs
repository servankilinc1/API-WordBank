using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utils
{
    public class ResultError:IResult
    {
        public ResultError(string _message)
        {
            Message = _message;
            Success = false;
        }
        public ResultError()
        {
            Success = false;
        }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
