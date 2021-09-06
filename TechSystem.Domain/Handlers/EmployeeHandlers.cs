
using TechSystem.Domain.Commands;
using TechSystem.Domain.Commands.EmployeeCommands.Inputs;

using Flunt.Notifications;
using BoBStore.Shared.Commands;
using TechSystem.Domain.Repositories.Contracts;
using TechSystem.Domain.ValueObjects;
using TechSystem.Domain.Entities;
using TechSystem.Domain.Commands.EmployeeCommands.Outputs;

namespace TechSystem.Domain.Handlers
{

    public class EmployeeHandler : Notifiable<Notification>,
                                    ICommandHandler<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public ICommandResults Handler(CreateEmployeeCommand Command)
        {
            var name = new Name(Command.FirstName, Command.LastName);
            var employee = new Employee(name, Command.Wage, (Enums.EGender)Command.Gender, (Enums.ERole)Command.Role);

            AddNotifications(employee);
            if (IsValid == false)
                return new EmployeeCommandResults(false, "Houve um erro ao registrar o funcionário", Notifications);

            _repository.Save(employee);

            return new EmployeeCommandResults(true, "Funcionário registrado com sucesso !", new
            {
                Id = employee.Id,
                Name = employee.Name,
                Wage = employee.Wage,
                Gender = employee.Gender,
                Role = employee.Role
            });


        }
    }
}