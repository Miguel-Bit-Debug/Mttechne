using Domain.DTOs;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPaymentService
{
    Task SaveTransaction(PaymentDTO paymentDTO);
    Task<PaymentConsolidated> GetTransactionsByReferenceDate(DateTime referenceDate);
    Task<IEnumerable<Payment>> GetAllTransactions();
}
