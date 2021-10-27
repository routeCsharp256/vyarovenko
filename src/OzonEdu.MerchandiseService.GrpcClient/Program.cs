using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using OzonEdu.MerchandiseService.Grpc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new MerchandiseServiceGrpc.MerchandiseServiceGrpcClient(channel);

            Console.WriteLine("GetMerch: " + $"{await client.GetMerchAsync(new GetMerchItemsRequest(), cancellationToken: CancellationToken.None)}");
            Console.WriteLine("GetMerchIsIssued: " + $"{await client.GetMerchIsIssuedAsync(new GetMerchIsIssuedItemsRequest(), cancellationToken: CancellationToken.None)}");
        }
    }
}
