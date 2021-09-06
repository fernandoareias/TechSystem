using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechSystem.Domain.ValueObjects;

namespace TechSystem.Test
{
    [TestClass]
    public class DocumentsTests
    {
        private readonly Document _documentValid = new Document("15046977079");
        private readonly Document _documentInvalid = new Document("15046977");

        // Deve retornar se documento for válido.
        [TestMethod]
        public void ShouldReturnIfDocumentIsValid()
        {
            Assert.AreEqual(true, _documentValid.IsValidate());
        }

        // Deve retornar se documento for inválido.
        [TestMethod]
        public void ShouldReturnIfDocumentIsInvalid()
        {
            Assert.AreEqual(false, _documentInvalid.IsValidate());
        }
    }
}
