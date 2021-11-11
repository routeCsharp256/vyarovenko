using OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate;
using OzonEdu.MerchandiseService.Domain.Models;
using System.Collections.Generic;
using System.Threading;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.EmloeeAgregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Employee FindByEmail(string email, CancellationToken cancellationToken);
        public void AddEmployee(string email, ClouthingSize size, CancellationToken cancellationToken);
        public void RemoveEmployee(Employee Employee, CancellationToken cancellationToken);
        public void NewOrder(bool flag, Employee Employee, CancellationToken cancellationToken, params MerchItem[] items);

        public void NewOrder(bool flag, Employee Employee, CancellationToken cancellationToken,
            IEnumerable<MerchItem> items);
    }
}
