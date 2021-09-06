
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechSystem.Domain.Commands.EmployeeCommands.Inputs;
using TechSystem.Domain.Handlers;
using TechSystem.Test.Fakes;

namespace TechSystem.Test.HandlerTests
{
    [TestClass]
    public class EmployeeHandlerTests
    {
        private readonly CreateEmployeeCommand _commandValid = new CreateEmployeeCommand();
        private readonly EmployeeHandler _handler = new EmployeeHandler(new FakeEmployeeRepository());

        public EmployeeHandlerTests()
        {
            _commandValid.FirstName = "Gnarson";
            _commandValid.LastName = "Gnarildo";
            _commandValid.Wage = 1100;
            _commandValid.Gender = 2;
            _commandValid.Role = 2;
        }

        [TestMethod]
        public void ShouldRegistryEmployeeIfCommandIsValid()
        {
            Assert.AreNotEqual(null, _handler.Handler(_commandValid));
        }

    }
}