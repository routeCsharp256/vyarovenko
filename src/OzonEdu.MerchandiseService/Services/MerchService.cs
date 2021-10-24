using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchService : IMerchandiseService
    {
        public Task<MerchandiseItem> GetMerch(CancellationToken token)
        {
            return Task.FromResult(new MerchandiseItem { Name="My test name" });
        }
        public Task<bool> GetMerchIsIssued(CancellationToken token)
        {
            return Task.FromResult(true);
        }
    }
}
