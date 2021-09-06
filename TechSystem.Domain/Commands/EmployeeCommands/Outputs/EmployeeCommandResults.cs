


namespace TechSystem.Domain.Commands.EmployeeCommands.Outputs
{
    public class EmployeeCommandResults : ICommandResults
    {
        public EmployeeCommandResults(bool sucess, string message, object data)
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