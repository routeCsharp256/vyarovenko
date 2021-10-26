using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Infrastructure.Logs.StartupFilters;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs.Services
{
    public static class AddLogs
    {
        public static IServiceCollection AddLogsService(this IServiceCollection services)
        {
            services.AddSingleton<IStartupFilter, LogsStartupFilter>();

            return services;
        }
    }
}
