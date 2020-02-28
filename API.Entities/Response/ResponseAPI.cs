using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace API.Entities.Response
{
    public class ResponseAPI
    {
        public ResponseAPI() { 
        
        }

        public ResponseAPI(HttpStatusCode code, string message) {
            Code = code;
            Message = message;
        }
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
    }
}
