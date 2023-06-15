using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task SaveTransaction(Payment payment);
    Task<PaymentConsolidated> GetTransactionsByReferenceDate(DateTime referenceDate);
    Task<IEnumerable<Payment>> GetAllTransactions();

}
