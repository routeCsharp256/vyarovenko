using Infrastru_ctureASPNET.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync(VersionModel.ToString());
        }
    }
}
