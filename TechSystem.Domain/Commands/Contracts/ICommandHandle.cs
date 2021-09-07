using TechSystem.Domain.Commands;

namespace BoBStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommands
    {
        ICommandResults Handler(T Command);
        ICommandResults Handler(T Command, System.Guid Id);
    }
}