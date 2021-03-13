
using CommonUtility.Exceptions;
using CommonUtility.Models.V1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;


namespace Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {

        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError("Something went wrong: | {Servicio} | {Error}", "BAL API", contextFeature.Error);

                        string message = contextFeature.Error.Message;

                        if (contextFeature.Error is ApiException)
                        {
                            ApiException exception = (ApiException)contextFeature.Error;
                            context.Response.StatusCode = (int)exception.StatusCode;
                            message = exception.Message;
                        }

                        var responseError = new BaseResponse()
                        {
                            Success = false,
                            Messagge = message,
                        };

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(responseError));
                    }
                });
            });
        }
    }
}
