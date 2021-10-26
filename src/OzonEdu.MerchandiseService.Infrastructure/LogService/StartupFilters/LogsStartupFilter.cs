﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Logs.Middlewares;
using System;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs.StartupFilters
{
    public class LogsStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<ResponseLoggingMiddleware>();
                app.UseMiddleware<RequestLoggingMiddleware>();
                next(app);
            };
        }
    }
}