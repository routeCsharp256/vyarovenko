using OzonEdu.MerchandiseService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        public Task<MerchandiseItem> GetMerch(CancellationToken token);
        public Task<bool> GetMerchIsIssued(CancellationToken token);

    }
}
