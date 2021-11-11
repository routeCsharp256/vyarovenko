using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.OrderMerch;

namespace OzonEdu.MerchandiseService.Infrastructure.Mediator.Handlers
{
    public sealed class OrderMerchCommandHandler : IRequestHandler<OrderMerchCommand>
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public OrderMerchCommandHandler(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }
        public async Task<Unit> Handle(OrderMerchCommand request, CancellationToken cancellationToken)
        {
            var Employee = _EmployeeRepository.FindByEmail(request.Employee.Email.Address, cancellationToken);
            if (Employee is null)
            {
                _EmployeeRepository.AddEmployee(request.Employee.Email.Address, request.Employee.Size, cancellationToken);
            }

            bool flag = OrderMerchByStock();
            _EmployeeRepository.NewOrder(flag, Employee, cancellationToken, request.MerchItems);
            await _EmployeeRepository.UnitOfWork?.SaveEntitiesAsync();
            return Unit.Value;
        }

        private bool OrderMerchByStock()
        {
            return true;
        }
    }
}
