using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechSystem.Domain.Commands.EmployeeCommands.Inputs;

namespace TechSystem.Test
{
    [TestClass]
    public class CreateEmployeeCommandTests
    {
        // Deve retornar caso command seja válido.
        [TestMethod]
        public void ShouldReturnIfCommandIsValid()
        {
            var command = new CreateEmployeeCommand();
            command.FirstName = "Gnarson";
            command.LastName = "Gnarilson";
            command.Wage = 1600;
            command.Gender = 2;
            command.Role = 2;

            command.Validate();

            Assert.AreEqual(true, command.IsValid);
        }

        // Deve retorna caso command seja inválido.
        [TestMethod]
        public void ShouldReturnIfCommandIsInvalid()
        {
            var command = new CreateEmployeeCommand();
            command.FirstName = "Gnarson";
            command.LastName = "";

            command.Validate();
            Assert.AreEqual(false, command.IsValid);

        }
    }
}