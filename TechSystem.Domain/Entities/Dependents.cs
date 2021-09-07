
using System.Reflection.Metadata;
using TechSystem.Domain.ValueObjects;
using TechSystem.Shared.Entities;
using TechSystem.Shared.ValueObjects;
using Document = TechSystem.Domain.ValueObjects.Document;

namespace TechSystem.Domain.Entities
{
    public class Dependents : Entity
    {
        public Dependents() { }
        public Dependents(Name name, Document document, System.Guid employee)
        {
            Name = name;
            Document = document;
            EmployeeId = employee;
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }

        public System.Guid EmployeeId { get; private set; }


    }
}
