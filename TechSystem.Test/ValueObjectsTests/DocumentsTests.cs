using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechSystem.Domain.ValueObjects;

namespace TechSystem.Test
{
    [TestClass]
    public class DocumentsTests
    {
        [TestMethod]
        public void ShouldReturnIfDocumentIsValid()
        {
            var document = new Document("15046977079");
            Assert.AreEqual(true, document.IsValidate());
        }

        [TestMethod]
        public void ShouldReturnIfDocumentIsInvalid()
        {
            var document = new Document("15046977");
            Assert.AreEqual(false, document.IsValidate());
        }
    }
}
