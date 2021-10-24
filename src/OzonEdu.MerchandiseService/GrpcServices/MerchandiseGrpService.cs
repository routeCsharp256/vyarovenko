using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchandiseGrpService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchandiseService _merchService;

        public MerchandiseGrpService(IMerchandiseService merchandiseService)
        {
            _merchService = merchandiseService;
        }

        public override async Task<GetMerchItemsResponse> GetMerch(Empty request, ServerCallContext context)
        {
            var merch = await _merchService.GetMerch(context.CancellationToken);
            return new GetMerchItemsResponse { Name = merch.Name };
        }
        public override async Task<GetMerchIsIssuedItemsResponse> GetMerchIsIssued(Empty request, ServerCallContext context)
        {
            var merch = await _merchService.GetMerchIsIssued(context.CancellationToken);
            return new GetMerchIsIssuedItemsResponse { IsIssued = merch };
        }
    }
}
