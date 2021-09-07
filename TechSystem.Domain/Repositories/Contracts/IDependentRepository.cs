


using System.Collections.Generic;
using TechSystem.Domain.Entities;
using TechSystem.Domain.Queries;

namespace TechSystem.Domain.Repositories.Contracts
{
    public interface IDependentRepository
    {
        void Create(Dependents dependent);

        CheckEmployee CheckEmployee(System.Guid Id);
        IEnumerable<GetDependentQueryResult> Get();
        IEnumerable<GetDependentQueryResult> GetByEmployeeId(System.Guid id);

    }
}