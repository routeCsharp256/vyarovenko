using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClients
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public interface IMerchkHttpClient
    {
    }

    public class MerchkHttpClient : IMerchkHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchkHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StockItemResponse>> V1GetAll(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("v1/api/stocks", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<StockItemResponse>>(body);
        }
    }
}
