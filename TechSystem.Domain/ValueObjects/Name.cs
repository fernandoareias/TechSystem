

using Flunt.Notifications;
using Flunt.Validations;
using TechSystem.Shared.ValueObjects;

namespace TechSystem.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            // Realiza validação do nome
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(firstName, 2, "FirstName", "O Nome deve ser maior que 2 caractéres.")
                .IsLowerThan(firstName, 80, "FirstName", "O Nome deve ser menor que 80 caractéres.")
                .IsGreaterThan(lastName, 2, "LastName", "O Sobrenome deve ser maior que 2 caractéres.")
                .IsLowerThan(lastName, 80, "LastName", "O Sobrenome deve ser menor que 80 caractéres.")

            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}