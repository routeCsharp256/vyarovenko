using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Infrastructure.gRPC.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.gRPC.Services
{
    public static class AddGrc
    {
        public static IServiceCollection AddGrpcService(this IServiceCollection services)
        {
            services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
            return services;
        }
    }
}
