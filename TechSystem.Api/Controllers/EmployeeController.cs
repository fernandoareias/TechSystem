


using System.Collections.Generic;
using BoBStore.Shared;
using Microsoft.AspNetCore.Mvc;
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


        [HttpGet]
        [Route("employees")]
        public IEnumerable<ListEmployeeQueryResults> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("Test")]
        public object Test()
        {
            return new { Connection = Settings.ConnectionString };
        }
    }

}