using System;
using Flunt.Notifications;

namespace TechSystem.Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>, IEquatable<Entity>
    {
        // Gera um novo ID
        public Entity()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; private set; }

        // Compata os IDs
        public bool Equals(Entity other) => Id == other.Id;
    }
}