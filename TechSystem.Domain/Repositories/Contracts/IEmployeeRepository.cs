

using System.Collections.Generic;
using TechSystem.Domain.Entities;
using TechSystem.Domain.Queries;

namespace TechSystem.Domain.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        void Save(Employee employee);
        IEnumerable<ListEmployeeQueryResults> Get();

        bool CheckEmail(string email);
    }
}