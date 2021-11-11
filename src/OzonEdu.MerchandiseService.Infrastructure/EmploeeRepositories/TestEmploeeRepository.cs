using OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate;
using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OzonEdu.MerchandiseService.Infrastructure.EmployeeRepositories
{
    public sealed class TestEmployeeRepository : IEmployeeRepository
    {
        IUnitOfWork IRepository<Employee>.UnitOfWork => throw new NotImplementedException();

        void IEmployeeRepository.AddEmployee(string email, ClouthingSize size, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.FindByEmail(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void IEmployeeRepository.NewOrder(bool flag, Employee Employee, CancellationToken cancellationToken,
            params MerchItem[] items)
        {
            throw new NotImplementedException();
        }

        void IEmployeeRepository.NewOrder(bool flag, Employee Employee, CancellationToken cancellationToken,
            IEnumerable<MerchItem> items)
        {
            throw new NotImplementedException();
        }

        void IEmployeeRepository.RemoveEmployee(Employee Employee, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
