

using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using TechSystem.Domain.Enums;
using TechSystem.Domain.ValueObjects;
using TechSystem.Shared.Entities;



namespace TechSystem.Domain.Entities
{
    public class Employee : Entity
    {
        // Lista interna
        private readonly IList<Dependents> _dependents;

        public Employee(Name name, decimal wage, EGender gender, ERole role)
        {
            Name = name;
            Wage = wage;
            Gender = gender;
            Role = role;
            _dependents = new List<Dependents>();

            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsTrue(Name.IsValid, "Name", "Name é inválido.")
                .IsGreaterThan(Wage, 1, "Wage", "Salário deve ser maior que zero.")
                .IsGreaterThan(((int)Gender), 1, "Gender", "Genero inválido.")
                .IsGreaterThan(((int)Role), 1, "Role", "Cargo inválido.")

            );
        }

        public Name Name { get; private set; }
        public decimal Wage { get; private set; }
        public EGender Gender { get; private set; }

        public ERole Role { get; private set; }

        // Lista de dependentes do funcionário.
        public IEnumerable<Dependents> Dependents => _dependents.ToArray();


        // Adiciona um dependente ha um funcionário.
        public void AddDependent(Dependents dependent)
        {

            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(dependent.Name.ToString(), "Dependent", "Dependente inválido.")
            );
            _dependents.Add(dependent);
        }

    }
}