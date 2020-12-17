using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            //testando se a string e nula ou vazia sem flunt
            // if(string.IsNullOrEmpty(FirstName))
            //     AddNotification("Name.FirstName", "Nome invalido");
            // if(string.IsNullOrEmpty(LastName))
            //     AddNotification("Name.LastName", "Sobrenome invalido");

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteries")
                .HasMinLen(FirstName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteries")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter no maximo 40 caracteries")
            );
        }

        public string FirstName {get; private set; }
        public string LastName { get; private set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}