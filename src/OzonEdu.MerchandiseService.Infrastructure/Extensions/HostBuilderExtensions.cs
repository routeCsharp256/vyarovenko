using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.gRPC.Services;
using OzonEdu.MerchandiseService.Infrastructure.Logs.Services;
using OzonEdu.MerchandiseService.Infrastructure.Swagger.Services;
using OzonEdu.MerchandiseService.Infrastructure.Live.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.Ready.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.Version.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.Exceptions.Filters;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddLogsService();
                services.AddSwaggerService();
                services.AddSingleton<IStartupFilter, VersionStartupFilter>();
                services.AddSingleton<IStartupFilter, ReadyStartupFilter>();
                services.AddSingleton<IStartupFilter, LiveStartupFilter>();
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddGrpcService();
            });
            return builder;
        }
    }
}
