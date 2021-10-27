using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OzonEdu.MerchandiseService.Infrastructure.Ready.Middlewares;
using System;

namespace OzonEdu.MerchandiseService.Infrastructure.Ready.StartupFilters
{
    public class ReadyStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                //app.Map("/ready", builder => builder.UseMiddleware<ReadyMiddleware>());
                app.Map("/ready", b => b.Run(c => c.Response.WriteAsync("ready")));
                next(app);
            };
        }
    }
}
