using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OzonEdu.MerchandiseService.Infrastructure.Version.Models;
using System.Text.Json;
using System;

namespace OzonEdu.MerchandiseService.Infrastructure.Version.StartupFilters
{
    public class VersionStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", b => b.Run(c => c.Response.WriteAsync(JsonSerializer.Serialize(new VersionModel()))));
                next(app);
            };
        }
    }
}
