using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using TechSystem.Shared.Entities;

namespace TechSystem.Domain.Entities
{
    public class Department : Entity
    {
        private readonly IList<Employee> _employee;
        public Department(decimal budget, Guid supervisorId)
        {
            Budget = budget;
            SupervisorId = supervisorId;
            _employee = new List<Employee>();
        }

        public decimal Budget { get; private set; }
        public System.Guid SupervisorId { get; private set; }
        public IEnumerable<Employee> Employees => _employee.ToArray();


        void AddEmployee(Employee emp)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsTrue(emp.IsValid, "Employee", "Não foi possível registrar o funcionário.")
            );

            _employee.Add(emp);
        }

    }
}