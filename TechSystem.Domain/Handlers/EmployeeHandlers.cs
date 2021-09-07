
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
            // Criação da VO
            var name = new Name(Command.FirstName, Command.LastName);

            // Criação do Funcionário.
            var employee = new Employee(name, Command.Wage, (Enums.EGender)Command.Gender, (Enums.ERole)Command.Role);

            // Verficia o funcionário
            AddNotifications(employee);

            // Caso inválido, retorna as notificações.
            if (IsValid == false)
                return new EmployeeCommandResults(false, "Houve um erro ao registrar o funcionário", Notifications);

            // Registra o funcionário no banco
            _repository.Save(employee);

            // Retorna um command result
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