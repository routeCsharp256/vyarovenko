using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OzonEdu.MerchandiseService.Infrastructure.Swagger.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.Version.Models;
using System;
using System.IO;

namespace OzonEdu.MerchandiseService.Infrastructure.Swagger.Services
{
    public static class AddSwagger
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = VersionModel.Name,
                        Version = VersionModel.Version
                    });

                options.CustomSchemaIds(x => x.FullName);

                var xmlFileName = VersionModel.Name + ".xml";
                var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                options.IncludeXmlComments(xmlFilePath);
            });

            return services;
        }
    }
}
