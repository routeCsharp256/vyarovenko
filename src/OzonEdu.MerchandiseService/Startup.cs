using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Services.Interfaces;
using OzonEdu.MerchandiseService.Services;
using OzonEdu.MerchandiseService.GrpcServices;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace OzonEdu.MerchandiseService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMerchandiseService, MerchService>();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers().RequireHost("*:5000");
                endpoints.MapGrpcService<MerchandiseGrpService>().RequireHost("*:5001");
            });
        }
    }
}