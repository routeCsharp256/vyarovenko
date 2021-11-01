using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

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
                    var originalResponseBody = context.Response.Body;
                    using var memmoryStreamResponseBody = new MemoryStream();
                    context.Response.Body = memmoryStreamResponseBody;
                    await LogRequest(context);
                    await _next(context);
                    await LogResponse(context);
                    await memmoryStreamResponseBody.CopyToAsync(originalResponseBody);
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
                _logger.LogDebug("RequestLog:\nRoute: {Route}\nHeaders: {@headers}",
                   context.Request.Path,
                   context.Request.Headers.ToDictionary(x => x.Key, x => (string)x.Value));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request");
            }
        }
        private async Task LogResponse(HttpContext context)
        {
            try
            {
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                _logger.LogDebug("ResponseLog:\nRoute: {Route}\nHeaders: {@headers}\nBody: {Body}",
                    context.Request.Path,
                    context.Response.Headers.ToDictionary(x => x.Key, x => (string)x.Value),
                    responseBody);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response");
            }
        }
    }
}
