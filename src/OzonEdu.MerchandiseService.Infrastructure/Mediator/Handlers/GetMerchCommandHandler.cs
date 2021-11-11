using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Infrastructure.Mediator.Commands.GetMerch;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Mediator.Handlers
{
    public sealed class GetMerchCommandHandler : IRequestHandler<GetMerchCommand, List<MerchItem>>
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public GetMerchCommandHandler(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public Task<List<MerchItem>> Handle(GetMerchCommand request, CancellationToken cancellationToken)
        {
            var Employee = _EmployeeRepository.FindByEmail(request.Email, cancellationToken);
            return Task.FromResult(Employee.GetReceivedMerchItems());
        }
    }
}
