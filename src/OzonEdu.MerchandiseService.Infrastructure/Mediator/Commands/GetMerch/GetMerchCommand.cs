using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Mediator.Commands.GetMerch
{
    public sealed class GetMerchCommand : IRequest<List<MerchItem>>
    {
        public string Email { get; set; }
    }
}
