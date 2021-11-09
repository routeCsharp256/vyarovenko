using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.ConsoleHttpClient
{
    public interface IMerchHttpClient
    {
        string GetLive(CancellationToken token);
        Task<List<MerchModel>> GetMerch(string email, CancellationToken token);
        string GetReady(CancellationToken token);
        string GetVersion(CancellationToken token);
        string OrderMerch(OrderMerchModel order, CancellationToken token);
    }
}
