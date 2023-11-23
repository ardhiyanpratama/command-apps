using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps.Helper
{
    public class ResponseException
    {
        public int Code { get; }

        public string? Message { get; }

        public ResponseException(int code, string? message)
        {
            this.Code = code;
            this.Message = message;
        }
    }
}
