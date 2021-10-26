﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OzonEdu.MerchandiseService.Infrastructure.Logs.Models;
using System;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs
    .Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.Path != null)
                {
                    RequestLogModel logModel = new RequestLogModel();
                    if (context.Request.Headers.Count > 0)
                    {
                        if (context.Request.Headers["Content-Type"] == "application/grpc")
                        {
                            return;
                        }
                        foreach (var header in context.Request.Headers)
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
                _logger.LogError(e, "Could not log request");
            }
        }
    }

}
