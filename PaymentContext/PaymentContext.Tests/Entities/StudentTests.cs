using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.bin;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Diana", "Prince");
            _document = new Document("14526415014", EDocumentType.CPF);
            _email = new Email("diana@gmail.com");
            _address = new Address("Rua 1", "1234", "Bairro", "Thermyscira", "SP", "BR", "07951000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            
        }

        //testar a assinatura de um estudante
        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {   
            //estamos criando uma assinatra, e é para dar erro não deixar fazer duas assinaturas
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "DIANA CORP", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            
            //Assert.Fail();
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            //deve retornar um erro quando a subscription nao tiver pagamento

            _student.AddSubscription(_subscription);
            
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "DIANA CORP", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            
            Assert.IsTrue(_student.Valid);
        }

        //[TestMethod]
        // public void AdicionarAssinatura()
        // {
            // var subscription = new Subscription(null);
            // var student = new Student("Kemylly", "Santos", "12345678912", "kemylly@gmail.com");

            // //chamando o metodo, e assim passa pelo o metodo e uma validacao
            // student.AddSubscription(subscription);

            //notificacoes padronizadas
            // var name = new Name("Teste", "Teste");
            // foreach (var not in name.Notifications)
            // {
            //     not.Message;
            // }
        // }
    }
}
