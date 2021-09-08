

using System;
using System.Collections.Generic;
using System.Data;
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
            return _context.Connection.Query<ListEmployeeQueryResults>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [Wage], [Gender], [Role] FROM [Employee]");
        }



        public IEnumerable<ListEmployeeAndDependentsQueryResults> GetListEmployeesAndDependents()
        {
            // https://renatogroffe.medium.com/dapper-relacionamentos-um-para-um-e-um-para-muitos-exemplos-em-asp-net-core-cfb0bf0668
            var dadosx = _context
                   .Connection
                   .Query<dynamic>("SELECT E.[Id], CONCAT(E.[FirstName], ' ', E.[LastName]) AS [Name], E.[Wage] ,E.[Gender], E.[Role], D.Id AS Dependents_Id ,CONCAT(D.FirstName, ' ', D.LastName) AS Dependents_Name FROM [Employee] AS E INNER JOIN Dependents AS D ON E.[Id] = D.[EmployeeId] ORDER BY E.FirstName, D.FirstName");
            // Realiza o mapeamento das Entidades com Slapper.Automapper
            AutoMapper.Configuration.AddIdentifier(typeof(ListEmployeeAndDependentsQueryResults), "Id");
            AutoMapper.Configuration.AddIdentifier(typeof(ListDependentsQueryResults), "Id");

            List<ListEmployeeAndDependentsQueryResults> employeesx = (AutoMapper.MapDynamic<ListEmployeeAndDependentsQueryResults>(dadosx) as IEnumerable<ListEmployeeAndDependentsQueryResults>).ToList();

            return employeesx;
        }

        public void Create(Employee employee)
        {
            _context.Connection.Execute("spCreateEmployee",
                new
                {
                    Id = employee.Id,
                    FirstName = employee.Name.FirstName,
                    LastName = employee.Name.LastName,
                    Wage = employee.Wage,
                    Gender = employee.Gender,
                    Role = employee.Role
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void Update(Employee employee)
        {
            _context.Connection.Execute("spUpdateEmployee",
               new
               {
                   Id = employee.Id,
                   FirstName = employee.Name.FirstName,
                   LastName = employee.Name.LastName,
                   Wage = employee.Wage,
                   Gender = employee.Gender,
                   Role = employee.Role
               },
               commandType: CommandType.StoredProcedure
           );
        }

        public void Delete(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public ListEmployeeQueryResults GetById(Guid Id)
        {
            return _context.Connection.Query<ListEmployeeQueryResults>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [Wage], [Gender], [Role] FROM [Employee] WHERE [Id] = Id").FirstOrDefault();
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