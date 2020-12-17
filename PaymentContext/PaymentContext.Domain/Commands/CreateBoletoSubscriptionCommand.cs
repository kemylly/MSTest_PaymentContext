using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand //command de entrada
    {

        public string FirstName {get; set; }  //student
        public string LastName { get; set; } //student
        public string Document { get; set; }  //Number //student  - cpf
        public string Email { get; set; }  //Address //student

        public string BarCode { get; set; }  //boletoPayment
        public string BoletoNumber { get; set; } //boletoPayment

        public string PaymentNumber { get; set; }  //Number
        public DateTime PaidDate { get; set; }  //data de pagamento
        public DateTime ExpireDate { get; set; }  //data de expiracao
        public decimal Total { get; set; } //total
        public decimal TotalPaid { get; set; }  //total pago
        public string Payer { get; set; }  //pagante
        public string PayerDocument { get; set; }  //Document document - cpf ou cnpj
        public EDocumentType PayerDocumentType { get; set; }  //tipo do documento do pagante
        
        //enreço do pagante - Address - address
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }  

        public string PayerEmail { get; set; }  //email do pagante

        public void Validate()
        {
            //aqui voce pode colocar validacoes - Não regras de negocio
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteries")
                .HasMinLen(FirstName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteries")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter no maximo 40 caracteries")
            );
        }
    }
}