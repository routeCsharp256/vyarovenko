using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace OzonEdu.MerchandiseService.Infrastructure.Live.StartupFilters
{
    public class LiveStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/live", b => b.Run(c => c.Response.WriteAsync("live")));
                next(app);
            };
        }
    }
}
