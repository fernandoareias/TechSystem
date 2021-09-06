


using System.Collections.Generic;
using TechSystem.Domain.Entities;
using TechSystem.Domain.Queries;
using TechSystem.Domain.Repositories.Contracts;

namespace TechSystem.Test.Fakes
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        public bool CheckEmail(string email)
        {
            return false;
        }

        public IEnumerable<ListEmployeeQueryResults> Get()
        {
            return new List<ListEmployeeQueryResults>();
        }

        public void Save(Employee employee)
        {

        }
    }
}