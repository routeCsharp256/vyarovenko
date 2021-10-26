using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Extensions;
using System.Net;

namespace OzonEdu.MerchandiseService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => 
                {
                    webBuilder.UseStartup<Startup>();
                })
                .AddInfrastructure();
    }
}