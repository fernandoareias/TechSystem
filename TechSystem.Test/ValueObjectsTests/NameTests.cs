using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechSystem.Domain.ValueObjects;

namespace TechSystem.Test
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnIfNameIsValid()
        {
            var document = new Name("Bobs", "Bobson");
            Assert.AreEqual(0, document.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnIfDocumentIsInvalid()
        {
            var document = new Name("b", "a");
            Assert.AreEqual(false, document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnIfDocumentIsEmpty()
        {
            var document = new Name("", "");
            Assert.AreEqual(false, document.IsValid);
        }
    }
}
