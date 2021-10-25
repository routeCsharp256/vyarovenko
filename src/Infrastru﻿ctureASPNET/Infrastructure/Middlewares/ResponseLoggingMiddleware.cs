using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Infrastru﻿ctureASPNET.Models;
using System;
using System.Threading.Tasks;

namespace Infrastru﻿ctureASPNET.Infrastructure.Middlewares
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
                if (context.Response.HasStarted && context.Response.Headers.Count > 0)
                {
                    if (context.Request.Headers["Content-Type"] == "application/grpc")
                    {
                        return;
                    }

                    ResponseLogModel logModel = new ResponseLogModel();

                    logModel.Route = context.Request.Path;
                    foreach (var header in context.Response.Headers)
                    {
                        logModel.Headers.Add(header.Key, header.Value);
                    }

                    _logger.LogInformation(logModel.ToString());
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
        }
    }

}
