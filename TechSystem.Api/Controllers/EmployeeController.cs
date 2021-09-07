


using System.Collections.Generic;
using BoBStore.Shared;
using Microsoft.AspNetCore.Mvc;
using TechSystem.Domain.Commands;
using TechSystem.Domain.Commands.EmployeeCommands.Inputs;
using TechSystem.Domain.Handlers;
using TechSystem.Domain.Queries;
using TechSystem.Domain.Repositories.Contracts;
using TechSystem.Shared;

namespace TechSystem.Api.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly EmployeeHandler _handler;

        public EmployeeController(IEmployeeRepository repository, EmployeeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        /*
                [HttpGet]
                [Route("v1/employees/dependents")]
                public IEnumerable<ListEmployeeAndDependentsQueryResults> GetEmployeesAndDependents()
                {
                    return _repository.GetListEmployeesAndDependents();
                }*/

        [HttpGet]
        [Route("v1/employees")]
        public IEnumerable<ListEmployeeQueryResults> Get()
        {
            return _repository.Get();
        }


        [HttpGet]
        [Route("v1/employees/{idEmployee}")]
        public ListEmployeeQueryResults GetById(System.Guid id)
        {
            return _repository.GetById(id);
        }



        [HttpPost]
        [Route("employees")]
        public ICommandResults Post([FromBody] CreateEmployeeCommand command)
        {
            var result = (ICommandResults)_handler.Handler(command);
            if (_handler.IsValid == false)
                return result;
            return result;
        }

    }
}