using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using PaymentContext.Domain.Repositories;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Entities;
using System;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.bin;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
        Notifiable,
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;  //injetando dependcias
        private readonly IEmailService _emailService;  //injetando dependcias

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)  //imjecao de dependecia
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //fail fast validations
            command.Validate();
            if(command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel fazer sua assinatura");
            }

            //verificar se documento está cadastrado, sem precisar do Banco
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Esse CPF já ests me uso");

            //verificar se email já está cadastrdo, sem precisar do Banco
            if(_repository.EmailExists(command.Email))
                AddNotification("Email", "Esse Email já ests me uso");
        
            //Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, 
                command.PaidDate, command.ExpireDate, command.Total, 
                command.TotalPaid, command.Payer, 
                new Document(command.PayerDocument, command.PayerDocumentType), 
                address, email);

            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //agrupar as validacoes
            AddNotifications(name, document, email, address, student, subscription, payment);

            //checar as notificacoes
            if(Invalid)
                return new CommandResult(false, "Desculpe, Não foi possivel realizar sua assinatura");
            
            //salvar as informações
            _repository.CreateSubscription(student);

            //enviar e-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada");

            //retornar informações
            return new CommandResult(true, "Assinatura realizada com suceso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //verificar se documento está cadastrado, sem precisar do Banco
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Esse CPF já esta em uso");

            //verificar se email já está cadastrdo, sem precisar do Banco
            if(_repository.EmailExists(command.Email))
                AddNotification("Email", "Esse Email já esta em uso");
        
            //Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar as entidades, esa regiao muda de boleto para ca
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(
                command.TransactionCode, 
                command.PaidDate, 
                command.ExpireDate, 
                command.Total, 
                command.TotalPaid, 
                command.Payer, 
                new Document(command.PayerDocument, command.PayerDocumentType), 
                address, 
                email);

            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //agrupar as validacoes
            AddNotifications(name, document, email, address, student, subscription, payment);

            //checar as notificacoes
            if(Invalid)
                return new CommandResult(false, "Desculpe, Não foi possivel realizar sua assinatura");

            //salvar as informações
            _repository.CreateSubscription(student);

            //enviar e-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada");

            //retornar informações
            return new CommandResult(true, "Assinatura realizada com suceso");
        }
    }
}