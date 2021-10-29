using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Serilog;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs
    .Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if ((context.Request.Path != null) &&
                    (!string.Equals(context.Request.ContentType, "application/grpc", StringComparison.OrdinalIgnoreCase)))
                {
                    var originalBody = context.Response.Body;
                    using var newBody = new MemoryStream();
                    context.Response.Body = newBody;
                    await LogRequest(context);
                    await _next(context);
                    await LogResponse(context, newBody).Result.CopyToAsync(originalBody);
                }
                else await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log");
                await _next(context);
            }
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                Log.Debug("RequestLog:\nRoute: {Route}\nHeaders: {@headers}",
                   context.Request.Path,
                   context.Request.Headers.ToDictionary(x => x.Key, x => (string)x.Value));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request");
            }
        }
        private async Task<MemoryStream> LogResponse(HttpContext context, MemoryStream newBody)
        {
            try
            {
                newBody.Seek(0, SeekOrigin.Begin);
                var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
                newBody.Seek(0, SeekOrigin.Begin);

                Log.Debug("ResponseLog:\nRoute: {Route}\nHeaders: {@headers}\nBody: {Body}",
                    context.Request.Path,
                    context.Response.Headers.ToDictionary(x => x.Key, x => (string)x.Value),
                    responseBody);
                return newBody;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response");
                return newBody;
            }
        }
    }
}
