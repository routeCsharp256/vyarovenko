using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Infrastru﻿ctureASPNET.Infrastructure.Middlewares;
using System;

namespace Infrastru﻿ctureASPNET.Infrastructure.StartupFilters
{
    public class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<ResponseLoggingMiddleware>();
                app.UseMiddleware<RequestLoggingMiddleware>();
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map("/ready", builder => builder.UseMiddleware<ReadyMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<LiveMiddleware>());
                next(app);
            };
        }
    }
}
