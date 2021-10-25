using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastru﻿ctureASPNET.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetEntryAssembly().GetName().Version?.ToString() ?? "no version";
            var serviceName = Assembly.GetEntryAssembly().GetName().Name?.ToString() ?? "no name";
            VersionModel model = new VersionModel 
            {
                Version= version, 
                ServiceName= serviceName 
            };
            await context.Response.WriteAsync(model.ToString());
        }
    }
    public class VersionModel
    {
        public string? Version { get; set; }
        public string? ServiceName { get; set; }
        public override string ToString()
        {
            return "{" + $"\"version\":\"{Version}\", \"serviceName\": \"{ServiceName}\"" + "}";
        }
    }
}
