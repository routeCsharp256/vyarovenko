using System;
using System.Collections.Generic;
using System.Threading;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.ConsoleHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MerchHttpClient("http://localhost:5000");

            var order = new OrderMerchModel
            {
                Employee = new Employee { Email = "test@gmail.com", Size = "XL" },
                MerchItems = new List<MerchModel>
                {
                    new MerchModel {ItemType = "Bag", Quantity = 3, Tag = "test"},
                    new MerchModel {ItemType = "TShort", Quantity = 1, Tag = "test2"}
                }
            };

            var status = client.OrderMerch(order, CancellationToken.None);
            Console.WriteLine(status);

            var response = client.GetMerch("test@gmail.com", CancellationToken.None);
            response.Result.ForEach((i) =>
                Console.WriteLine($"ItemType = {i.ItemType}, Quantity = {i.Quantity}, Tag = {i.Tag}"));

            Console.WriteLine("GetVersion: " + client.GetVersion(CancellationToken.None));
            Console.WriteLine("GetLive: " + client.GetLive(CancellationToken.None));
            Console.WriteLine("GetReady: " + client.GetReady(CancellationToken.None));
            Console.ReadKey();
        }
    }
}
