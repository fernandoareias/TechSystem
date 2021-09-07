



using BoBStore.Shared.Commands;
using Flunt.Notifications;
using TechSystem.Domain.Commands;
using TechSystem.Domain.Commands.DependentCommands.Inputs;
using TechSystem.Domain.Commands.EmployeeCommands.Outputs;
using TechSystem.Domain.Entities;
using TechSystem.Domain.Repositories.Contracts;
using TechSystem.Domain.ValueObjects;

namespace TechSystem.Domain.Handlers
{
    public class DependentHandlers : Notifiable<Notification>, ICommandHandler<CreateDependentCommands>
    {
        private readonly IDependentRepository _repository;


        public DependentHandlers(IDependentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResults Handler(CreateDependentCommands Command, System.Guid Id)
        {
            var name = new Name(Command.FirstName, Command.LastName);
            var document = new Document(Command.Document);
            var employee = _repository.CheckEmployee(Id);
            if (employee == null)
                return new DependentCommandResults(false, "não foi possível encontrar o funcionário.", Notifications);
            var dependent = new Dependents(name, document, Id);

            AddNotifications(dependent);

            // Caso inválido, retorna as notificações.
            if (IsValid == false)
                return new DependentCommandResults(false, "Houve um erro ao registrar o dependente", Notifications);

            _repository.Create(dependent);

            return new DependentCommandResults(true, "Dependente registrado com sucesso !", new
            {
                Id = dependent.Id,
                Name = dependent.Name,
                Document = dependent.Document
            });
        }

        public ICommandResults Handler(CreateDependentCommands Command)
        {
            throw new System.NotImplementedException();
        }
    }
}