



using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using TechSystem.Domain.Entities;
using TechSystem.Domain.Queries;
using TechSystem.Domain.Repositories.Contracts;
using TechSystem.Infra.DataContext;

namespace TechSystem.Infra.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        private readonly TechDataContext _context;

        public DependentRepository(TechDataContext context)
        {
            _context = context;
        }
        public CheckEmployee CheckEmployee(Guid Id)
        {
            return _context.Connection.Query<CheckEmployee>("SELECT [Id] FROM [Employee] WHERE [Id] = Id").FirstOrDefault();
        }

        public void Create(Dependents dependent)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<GetDependentQueryResult> Get()
        {
            return _context.Connection.Query<GetDependentQueryResult>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [EmployeeId] FROM [Dependents]");
        }

        public IEnumerable<GetDependentQueryResult> GetByEmployeeId(Guid id)
        {
            return _context.Connection.Query<GetDependentQueryResult>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [EmployeeId] FROM [Dependents] WHERE [EmployeeId] = id");
        }
    }
}