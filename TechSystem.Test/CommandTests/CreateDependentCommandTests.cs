using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechSystem.Domain.Commands.DependentCommands.Inputs;
using TechSystem.Domain.Commands.EmployeeCommands.Inputs;

namespace TechSystem.Test
{
    [TestClass]
    public class CreateDependentCommandTests
    {
        // Deve retornar caso command seja válido.
        [TestMethod]
        public void ShouldReturnIfCommandIsValid()
        {
            var command = new CreateDependentCommands();
            command.FirstName = "Gnarson";
            command.LastName = "Gnarilson";
            command.Document = "14270066792";

            command.Validate();

            Assert.AreEqual(true, command.IsValid);
        }

        // Deve retorna caso command seja inválido.
        [TestMethod]
        public void ShouldReturnIfCommandIsInvalid()
        {
            var command = new CreateDependentCommands();
            command.FirstName = "Gnarson";
            command.LastName = "";
            command.Document = "1";

            command.Validate();
            Assert.AreEqual(false, command.IsValid);

        }
    }
}