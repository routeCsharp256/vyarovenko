using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate;
using OzonEdu.MerchandiseService.Infrastructure.EmployeeRepositories;
using OzonEdu.MerchandiseService.Infrastructure.Exceptions.Filters;
using OzonEdu.MerchandiseService.Infrastructure.gRPC.Interceptors;
using OzonEdu.MerchandiseService.Infrastructure.Live.HelthCheck;
using OzonEdu.MerchandiseService.Infrastructure.Logs.StartupFilters;
using OzonEdu.MerchandiseService.Infrastructure.Mediator.Handlers;
using OzonEdu.MerchandiseService.Infrastructure.Ready.HealthCheck;
using OzonEdu.MerchandiseService.Infrastructure.Swagger.Services;
using OzonEdu.MerchandiseService.Infrastructure.Version.StartupFilters;

namespace OzonEdu.MerchandiseService.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, LogsStartupFilter>();
                services.AddSwaggerService();
                services.AddSingleton<IStartupFilter, VersionStartupFilter>();
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
                services.AddTransient<IEmployeeRepository, TestEmployeeRepository>();
                services.AddMediatR(typeof(OrderMerchCommandHandler).Assembly);
                services.AddHealthChecks()
                    .AddCheck<LiveHelthCheck>("live_health_check", tags: new[] { "live" })
                    .AddCheck<ReadyHealthCheck>("ready_health_check", tags: new[] { "ready" });
            });
            return builder;
        }
    }
}
