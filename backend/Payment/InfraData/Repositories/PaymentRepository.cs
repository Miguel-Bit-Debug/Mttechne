using Domain.Interfaces.Repositories;
using Domain.Models;
using MongoDB.Driver;
using Product.InfraData.Data;

namespace InfraData.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly IMongoCollection<Payment> _collection;

    public PaymentRepository(IMongoDbContext dbContext)
    {
        _collection = dbContext.Collection<Payment>();
    }

    public async Task<IEnumerable<Payment>> GetAllTransactions()
    {
        var payments = await _collection.FindAsync(obj => true);
        return payments.ToList();
    }

    public async Task<PaymentConsolidated> GetTransactionsByReferenceDate(DateTime referenceDate)
    {
        var payments = await _collection.Find(obj => obj.PaymentDate == referenceDate).ToListAsync();
        decimal totalPaymentAmount = 0;

        foreach (var payment in payments)
        {
            totalPaymentAmount += payment.PaymentAmount;
        }

        var paymentsConsolidated = new PaymentConsolidated(payments, totalPaymentAmount);

        return paymentsConsolidated;
    }

    public async Task SaveTransaction(Payment payment)
    {
        await _collection.InsertOneAsync(payment);
    }
}
