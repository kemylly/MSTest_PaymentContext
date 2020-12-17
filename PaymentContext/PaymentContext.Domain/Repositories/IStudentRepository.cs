using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository  // Repository Pattern
    {
        //abstracao, para isolar o dominio do mundo 
         bool DocumentExists(string document);  //testar se já existe no banco
         bool EmailExists(string email);
         void CreateSubscription(Student student);
    }
}