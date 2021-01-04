using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRest.Web.ErrorHelper
{
    public class errorHelper
    {

        public static ResponseObject Response(int StatusCode, string Message)
        {
            return new ResponseObject()
            {
                 StatusCode=StatusCode,
                Message = Message
            };
        }
    }

    public class ResponseObject
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
