using CommonUtility.Models.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtility.Helpers
{
    public static class ResponseHelper
    {
        public static BaseResponse SetResponse(bool success, string messagge, object data)
            => new BaseResponse()
            {
                Success = success,
                Messagge = messagge,
                Data = data
            };
    }
}
