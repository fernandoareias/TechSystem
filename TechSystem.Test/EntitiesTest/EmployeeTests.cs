using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechSystem.Domain.Entities;
using TechSystem.Domain.ValueObjects;

namespace TechSystem.Test
{
    [TestClass]
    public class EmployeeTests
    {
        private readonly Employee _employeeValid = new Employee(new Name("Bobi", "Bobson"), 1650, Domain.Enums.EGender.Male, Domain.Enums.ERole.Employee);
        private readonly Employee _employeeInvalid = new Employee(new Name("", ""), 0, 0, 0);

        [TestMethod]
        public void ShouldReturnIfEmployeeIsValid()
        {
            Assert.AreEqual(true, _employeeValid.IsValid);
        }

        [TestMethod]
        public void ShouldReturnIfEmployeeIsInvalid()
        {
            Assert.AreEqual(false, _employeeInvalid.IsValid);
        }
    }
}
