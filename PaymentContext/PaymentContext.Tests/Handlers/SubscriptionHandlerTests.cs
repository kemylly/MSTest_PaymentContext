using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;
namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Diana";  
            command.LastName = "Prince"; 
            command.Document = "12345678912";  
            command.Email = "kemylly@gmail.com";  
            command.BarCode = "123456789";  
            command.BoletoNumber = "12345678"; 
            command.PaymentNumber = "123456";  
            command.PaidDate = DateTime.Now;  
            command.ExpireDate = DateTime.Now.AddMonths(1);  
            command.Total = 60; 
            command.TotalPaid = 60;  
            command.Payer = "Diana CORP";  
            command.PayerDocument = "12345678912";  
            command.PayerDocumentType = EDocumentType.CPF;  
            command.Street = "rua cinco";
            command.Number = "50";
            command.Neighborhood = "Bairro";
            command.City = "Themyscira";
            command.State = "SP";
            command.Country = "BR";
            command.ZipCode = "07951000";  
            command.PayerEmail = "diana@gmail.com";
            
            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}