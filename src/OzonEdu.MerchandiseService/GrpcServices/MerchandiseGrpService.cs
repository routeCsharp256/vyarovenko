using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseGrpService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        public MerchandiseGrpService()
        {
        }

        public override Task<GetMerchItemsResponse> OrderMerch(OrderMerchItemsRequest request,
            ServerCallContext context)
        {
            return base.OrderMerch(request, context);
        }
    }
}
