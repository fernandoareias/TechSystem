


using Flunt.Notifications;
using Flunt.Validations;

namespace TechSystem.Domain.Commands.DependentCommands.Inputs
{
    public class CreateDependentCommands : Notifiable<Notification>, ICommands
    {
        public CreateDependentCommands() { }
        public CreateDependentCommands(string firstName, string lastName, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public System.Guid EmployeeId { get; private set; }

        public void SetEmployee(System.Guid id) => EmployeeId = id;
        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(FirstName, 2, "FirstName", "Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(FirstName, 80, "FirstName", "Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(LastName, 2, "LastName", "Sobrenome deve ser maior que 2 caractéres.")
                .IsLowerThan(LastName, 80, "LastName", "Sobrenome deve ser menor que 80 caractéres.")
                .IsGreaterThan(Document, 1, "Document", "Documento deve ser maior que 1 caractér.")
                .IsLowerThan(Document, 15, "Document", "Documento deve ser menor que 15 caractéres.")
            );

            return IsValid;
        }
    }
}