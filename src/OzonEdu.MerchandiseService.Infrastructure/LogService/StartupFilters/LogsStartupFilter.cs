using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Logs.Middlewares;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs.StartupFilters
{
    public sealed class LogsStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<LoggingMiddleware>();
                next(app);
            };
        }
    }
}
