using OzonEdu.MerchandiseService.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.ConsoleHttpClient
{
    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetMerchResponseModel> GetMerch(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/v1/api/merch/GetMerch", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<GetMerchResponseModel>(body);
        }
        public async Task<bool> GetMerchIsIssued(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/v1/api/merch/GetMerchIsIssued", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<bool>(body);
        }
        public async Task<string> GetVersion(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/version", token);
            return await response.Content.ReadAsStringAsync(token);
        }
        public async Task<string> GetLive(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/live", token);
            return response.StatusCode.ToString();
        }
        public async Task<string> GetReady(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("/ready", token);
            return response.StatusCode.ToString();
        }
    }
}
