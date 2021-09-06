using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechSystem.Domain.ValueObjects;

namespace TechSystem.Test
{
    [TestClass]
    public class NameTests
    {
        private readonly Name _nameValid = new Name("Bobs", "Bobson");
        private readonly Name _nameInvalid = new Name("", "");
        [TestMethod]
        public void ShouldReturnIfNameIsValid()
        {
            Assert.AreEqual(true, _nameValid.IsValid);
        }

        [TestMethod]
        public void ShouldReturnIfNameIsInvalid()
        {
            Assert.AreEqual(false, _nameInvalid.IsValid);
        }


    }
}
