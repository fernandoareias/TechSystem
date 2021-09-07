

using System.Collections.Generic;
using TechSystem.Domain.Entities;
using TechSystem.Domain.Queries;

namespace TechSystem.Domain.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        IEnumerable<ListEmployeeAndDependentsQueryResults> GetListEmployeesAndDependents();
        IEnumerable<ListEmployeeQueryResults> Get();

        ListEmployeeQueryResults GetById(System.Guid Id);

        bool CheckEmail(string email);
    }
}