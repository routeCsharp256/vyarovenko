using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Infrastru﻿ctureASPNET.Infrastructure.Filters;
using Infrastru﻿ctureASPNET.Infrastructure.Interceptors;
using Infrastru﻿ctureASPNET.Infrastructure.StartupFilters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Infrastru_ctureASPNET.Models;

namespace Infrastru﻿ctureASPNET.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();

                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", 
                        new OpenApiInfo 
                        { 
                            Title = VersionModel.ServiceName, 
                            Version = VersionModel.Version
                        });

                    options.CustomSchemaIds(x => x.FullName);

                    var xmlFileName = VersionModel.ServiceName + ".xml";
                    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                    options.IncludeXmlComments(xmlFilePath);

                });
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
            });
            return builder;
        }
    }
}
