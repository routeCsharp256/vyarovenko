using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.OrderMerch
{
    public sealed class OrderMerchCommand : IRequest
    {
        public Employee Employee { get; set; }
        public IReadOnlyList<MerchItem> MerchItems { get; set; }
    }
}
