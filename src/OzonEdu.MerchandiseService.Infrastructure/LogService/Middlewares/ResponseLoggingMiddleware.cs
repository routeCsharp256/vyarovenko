using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OzonEdu.MerchandiseService.Infrastructure.Logs.Models;
using System;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            await LogResponse(context);
        }

        private async Task LogResponse(HttpContext context)
        {
            try
            {
                if (context.Response.HasStarted)
                {
                    ResponseLogModel logModel = new ResponseLogModel();
                    if (context.Response.Headers.Count > 0)
                    {
                        if (context.Request.Headers["Content-Type"] == "application/grpc")
                        {
                            return;
                        }
                        foreach (var header in context.Response.Headers)
                        {
                            logModel.Headers.Add(header.Key, header.Value);
                        }
                    }
                    logModel.Route = context.Request.Path;
                    
                    _logger.LogInformation(logModel.ToString());
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response");
            }
        }
    }

}
