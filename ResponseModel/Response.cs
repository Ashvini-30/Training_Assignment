
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WebApplication3.ResponseModel
{
    public class Response
    {
        public Response()
        {
            ErrorMessage = new List<string>();
        }
        public List<string> ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
    }
}