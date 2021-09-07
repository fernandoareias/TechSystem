


namespace TechSystem.Domain.Commands.EmployeeCommands.Outputs
{
    public class DependentCommandResults : ICommandResults
    {
        public DependentCommandResults(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}