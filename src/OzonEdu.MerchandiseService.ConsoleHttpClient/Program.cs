using System;
using System.Net.Http;
using System.Threading;

namespace OzonEdu.MerchandiseService.ConsoleHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MerchHttpClient(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001")
            });
            Console.WriteLine("GetMerch: " + client.GetMerch(CancellationToken.None).Result);
            Console.WriteLine("GetMerchIsIssued: " + client.GetMerchIsIssued(CancellationToken.None).Result);
            Console.WriteLine("GetVersion: " + client.GetVersion(CancellationToken.None).Result);
            Console.WriteLine("GetLive: " + client.GetLive(CancellationToken.None).Result);
            Console.WriteLine("GetReady: " + client.GetReady(CancellationToken.None).Result);
        }
    }
}
