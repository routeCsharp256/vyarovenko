using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Infrastru﻿ctureASPNET.Infrastructure.Middlewares
{
    public class LiveMiddleware
    {
        public LiveMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await Task.FromResult(context.Response.StatusCode = StatusCodes.Status200OK);
        }
    }
}
