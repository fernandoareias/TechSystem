


using System;
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

        public IEnumerable<ListEmployeeAndDependentsQueryResults> GetListEmployeesAndDependents()
        {
            throw new System.NotImplementedException();
        }

        public void Create(Employee employee)
        {

        }

        public void Update(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public ListEmployeeQueryResults GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}