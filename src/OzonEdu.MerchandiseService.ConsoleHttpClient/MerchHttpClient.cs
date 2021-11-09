using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;
using RestSharp;

namespace OzonEdu.MerchandiseService.ConsoleHttpClient
{
    public sealed class MerchHttpClient : IMerchHttpClient
    {
        private readonly string _baseUrl;

        public MerchHttpClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public string OrderMerch(OrderMerchModel order, CancellationToken token)
        {
            var client = new RestClient($"{_baseUrl}/v1/api/merch");

            var body = JsonSerializer.Serialize(order, typeof(OrderMerchModel));

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = client.Execute(request);

            return response.StatusCode.ToString();
        }

        public async Task<List<MerchModel>> GetMerch(string email, CancellationToken token)
        {
            var client = new RestClient($"{_baseUrl}/v1/api/merch?email={email}");

            var request = new RestRequest(Method.GET);

            var response = await client.ExecuteAsync(request);
            var result = JsonSerializer.Deserialize<List<MerchModel>>(response.Content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (result is not null)
            {
                return result;
            }
            else throw new FormatException($"Response was: {response.Content}");
        }

        public string GetVersion(CancellationToken token)
        {
            var client = new RestClient($"{_baseUrl}/version");

            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            return response.Content;
        }

        public string GetLive(CancellationToken token)
        {
            var client = new RestClient($"{_baseUrl}/live");

            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            return response.StatusCode.ToString();
        }

        public string GetReady(CancellationToken token)
        {
            var client = new RestClient($"{_baseUrl}/ready");

            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            return response.StatusCode.ToString();
        }
    }
}
