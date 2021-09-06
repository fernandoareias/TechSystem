using Flunt.Notifications;
using Flunt.Validations;

namespace TechSystem.Domain.Commands.EmployeeCommands.Inputs
{
    public class CreateEmployeeCommand : Notifiable<Notification>, ICommands
    {
        public CreateEmployeeCommand() { }
        public CreateEmployeeCommand(string firstName, string lastName, decimal wage, int gender, int role)
        {
            FirstName = firstName;
            LastName = lastName;
            Wage = wage;
            Gender = gender;
            Role = role;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Wage { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(FirstName, 2, "FirstName", "Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(FirstName, 80, "FirstName", "Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(LastName, 2, "LastName", "Sobrenome deve ser maior que 2 caractéres.")
                .IsLowerThan(LastName, 80, "LastName", "Sobrenome deve ser menor que 80 caractéres.")
                .IsGreaterThan(Wage, 0, "Wage", "Salário deve ser maior que zero.")
                .IsGreaterThan(Gender, 0, "Gender", "Genero deve ser maior que zero.")
                .IsLowerThan(Gender, 8, "Gender", "Gender deve ser menor que 8.")
                .IsGreaterThan(Role, 0, "Role", "Cargo deve ser maior que zero.")
                .IsLowerThan(Role, 4, "Role", "Cargo deve ser menor que 4.")
            );
            return IsValid;
        }
    }
}