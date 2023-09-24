using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utils
{
    public class ResultSuccess:IResult
    {
        public ResultSuccess(string _message)
        {
            Message = _message;
            Success = true;
        }
        public ResultSuccess()
        {
            Success = true;
        }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
