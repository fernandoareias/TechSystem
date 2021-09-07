

using System.Collections.Generic;
using System.Linq;
using Dapper;
using Slapper;
using TechSystem.Domain.Entities;
using TechSystem.Domain.Queries;
using TechSystem.Domain.Repositories.Contracts;
using TechSystem.Infra.DataContext;
namespace TechSystem.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly TechDataContext _context;
        public EmployeeRepository(TechDataContext context)
        {
            _context = context;
        }

        public bool CheckEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListEmployeeQueryResults> Get()
        {
            var dadosx = _context
                   .Connection
                   .Query<dynamic>("SELECT E.[Id], CONCAT(E.[FirstName], ' ', E.[LastName]) AS [Name], E.[Wage] ,E.[Gender], E.[Role], D.Id AS Dependents_Id ,CONCAT(D.FirstName, ' ', D.LastName) AS Dependents_Name FROM [Employee] AS E INNER JOIN Dependents AS D ON E.[Id] = D.[EmployeeId] ORDER BY E.FirstName, D.FirstName");
            AutoMapper.Configuration.AddIdentifier(typeof(ListEmployeeQueryResults), "Id");
            AutoMapper.Configuration.AddIdentifier(typeof(ListDependentsQueryResults), "Id");

            List<ListEmployeeQueryResults> employeesx = (AutoMapper.MapDynamic<ListEmployeeQueryResults>(dadosx) as IEnumerable<ListEmployeeQueryResults>).ToList();

            return employeesx;
        }

        public void Save(Employee employee)
        {
            _context.Connection.Execute("spCreateEmployee",
                new
                {
                    Id = employee.Id,
                    FirstName = employee.Name.FirstName,
                    LastName = employee.Name.LastName,
                    Gender = employee.Gender,
                    Role = employee.Role
                }
            );
        }
    }
}



/* 
 _context
                   .Connection
                   .Query<ListEmployeeQueryResults, ListDependentsQueryResults, ListEmployeeQueryResults>("SELECT E.[Id], CONCAT(E.[FirstName], ' ', E.[LastName]) AS [Name], E.[Wage] ,E.[Gender], E.[Role], D.Id AS DependentId ,CONCAT(D.FirstName, ' ', D.LastName) AS Name FROM [Employee] AS E INNER JOIN Dependents AS D ON E.[Id] = D.[EmployeeId] ",
                   map: (ListEmployeeQueryResults, ListDependentsQueryResults) =>
                   {
                       ListEmployeeQueryResults.Dependents.Add(ListDependentsQueryResults);
                       return ListEmployeeQueryResults;
                   },
                   splitOn: "Id, DependentId");


*/