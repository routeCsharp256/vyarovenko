using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Swagger.Services;
using OzonEdu.MerchandiseService.Infrastructure.Live.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.Ready.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.Version.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.Exceptions.Filters;
using OzonEdu.MerchandiseService.Infrastructure.Logs.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.gRPC.Interceptors;
using Serilog;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.UseSerilog((context, services, configuration) => configuration
                .MinimumLevel.Debug()
                .WriteTo.Console())
                .ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, LogsStartupFilter>();
                services.AddSwaggerService();
                services.AddSingleton<IStartupFilter, VersionStartupFilter>();
                services.AddSingleton<IStartupFilter, ReadyStartupFilter>();
                services.AddSingleton<IStartupFilter, LiveStartupFilter>();
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
            });
            return builder;
        }
    }
}
