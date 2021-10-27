using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OzonEdu.MerchandiseService.Infrastructure.Logs.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Text;
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
                    (context.Request.Headers["Content-Type"].ToString().ToLower() != "application/grpc"))
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
                var logModel = new RequestLogModel
                {
                    Route = context.Request.Path,
                    Headers = context.Request.Headers.ToDictionary(x => x.Key, x => (string)x.Value)
                };

                _logger.LogDebug(logModel.ToString());
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

                var logModel = new ResponseLogModel
                {
                    Route = context.Request.Path,
                    Headers = context.Response.Headers.ToDictionary(x => x.Key, x => (string)x.Value),
                    Body = responseBody
                };

                _logger.LogDebug(logModel.ToString());
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
