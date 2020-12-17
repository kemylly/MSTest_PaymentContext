using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand //command de entrada
    {
        //funciona como uma camada de transferencia - dto
        public string FirstName {get; set; }  //student
        public string LastName { get; set; } //student
        public string Document { get; set; }  //Number //student  - cpf
        public string Email { get; set; }  //Address //student

        public string TransactionCode { get; set; }  //paypalpayment

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

        public string PayerEmail { get; set; }  //email do pagante

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}