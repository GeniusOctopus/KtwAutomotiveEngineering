using KtwAutomotiveEngineering.Entities.ErrorModel;
using KtwAutomotiveEngineering.Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace KtwAutomotiveEngineering
{
    public class GlobalExceptionHandler(ILogger logger) : IExceptionHandler
    {
        private readonly ILogger _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                httpContext.Response.StatusCode = contextFeature.Error switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                _logger.Error($"Something went wrong: {exception.Message}");

                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = contextFeature.Error.Message,
                }.ToString(), cancellationToken: cancellationToken);
            }

            return true;
        }
    }
}
