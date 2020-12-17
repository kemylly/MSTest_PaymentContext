using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            //exemplo para validar/ testar a validacao do command, mesmo não sendo necessario esse teste
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }

    }
}