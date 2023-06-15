using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task SaveTransaction(Payment payment);
}
