using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtility.Models.V1
{
    public class BaseResponse
    {
        private const string _message = "OK";
        private const bool _success = true;
        public BaseResponse()
        {
            Messagge = _message;
            Success = _success;
        }

        public string Messagge { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}
