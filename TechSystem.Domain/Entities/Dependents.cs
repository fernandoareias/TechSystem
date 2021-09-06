
using System.Reflection.Metadata;
using TechSystem.Domain.ValueObjects;
using TechSystem.Shared.Entities;
using TechSystem.Shared.ValueObjects;
using Document = TechSystem.Domain.ValueObjects.Document;

namespace TechSystem.Domain.Entities
{
    public class Dependents : Entity
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }



    }
}
