using System;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand //command de entrada
    {
        public string FirstName {get; set; }  //student
        public string LastName { get; set; } //student
        public string Document { get; set; }  //Number //student  - cpf
        public string Email { get; set; }  //Address //student

        public string CardHolderName { get; private set; }  //creditCardPayment
        public string CardNumber { get; private set; } //creditCardPayment
        public string LastTransactionNumber { get; private set; } //creditCardPayment

        public string PaymentNumber { get; set; }  //Number
        public DateTime PaidDate { get; set; }  //data de pagamento
        public DateTime ExpireDate { get; set; }  //data de expiracao
        public decimal Total { get; set; } //total
        public decimal TotalPaid { get; set; }  //total pago
        public string Payer { get; set; }  //pagante
        public string PayerDocument { get; set; }  //Document document - cpf ou cnpj
        public EDocumentType PayerDocumentType { get; set; }  //tipo do documento do pagante
        
        //enreço do pagante - Address - address
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }  

        public string PayerEmail { get; set; }
    }
}