using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
            //Assert.Fail();  //falhar
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("30334443000180", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        //testar varios ao mesmo tempo
        [TestMethod]
        [DataTestMethod]
        [DataRow("69772770091")]
        [DataRow("90910623040")]
        [DataRow("07382420043")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var  doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}