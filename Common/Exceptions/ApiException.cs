using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CommonUtility.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public ApiException(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message, Exception inner)
        : base(message, inner)
        {
            this.StatusCode = statusCode;
        }
    }
}
