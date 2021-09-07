


using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechSystem.Domain.Handlers;
using TechSystem.Domain.Queries;
using TechSystem.Domain.Repositories.Contracts;

namespace TechSystem.Api.Controllers
{
    public class DependentController : Controller
    {
        private readonly IDependentRepository _repository;
        private readonly DependentHandlers _handler;

        public DependentController(IDependentRepository repository, DependentHandlers handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/employee/dependents")]
        public IEnumerable<GetDependentQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/employee/{idEmployee}/dependents")]
        public IEnumerable<GetDependentQueryResult> GetByEmployeeId(System.Guid idEmployee)
        {
            return _repository.GetByEmployeeId(idEmployee);
        }
    }
}