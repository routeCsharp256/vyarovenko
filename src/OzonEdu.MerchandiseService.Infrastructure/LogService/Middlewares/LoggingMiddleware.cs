using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs
    .Middlewares
{
    public sealed class LoggingMiddleware
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
                if (string.Equals(context.Request.ContentType, "application/grpc", StringComparison.OrdinalIgnoreCase))
                    await _next(context);
                else
                {
                    var originalResponseBody = context.Response.Body;
                    using var memmoryStreamResponseBody = new MemoryStream();
                    context.Response.Body = memmoryStreamResponseBody;
                    LogRequest(context);
                    await _next(context);
                    await LogResponse(context);
                    await memmoryStreamResponseBody.CopyToAsync(originalResponseBody);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log");
                await _next(context);
            }
        }

        private async void LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering();
                    var buffer = new byte[context.Request.ContentLength.Value];
                    await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                    var bodyAsText = Encoding.UTF8.GetString(buffer);

                    _logger.LogInformation("RequestLog:" + $"{Environment.NewLine}" + "Route: {Route}" + $"{Environment.NewLine}" + "Headers: {@headers}" + $"{Environment.NewLine}" + "Body: {Body}",
                        context.Request.Path,
                        context.Request.Headers,
                        bodyAsText);

                    context.Request.Body.Position = 0;
                }
                else
                {
                    _logger.LogInformation("RequestLog:" + $"{Environment.NewLine}" + "Route: {Route}" + $"{Environment.NewLine}" + "Headers: {@headers}" + $"{Environment.NewLine}" + "Body:",
                        context.Request.Path,
                        context.Request.Headers,
                        Environment.NewLine);
                }
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

                _logger.LogInformation("ResponseLog:" + $"{Environment.NewLine}" + "Route: {Route}" + $"{Environment.NewLine}" + "Headers: {@headers}" + $"{Environment.NewLine}" + "Body: {Body}",
                    context.Request.Path,
                    context.Response.Headers,
                    responseBody,
                    Environment.NewLine);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response");
            }
        }
    }
}
