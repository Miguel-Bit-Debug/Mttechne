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

    public async Task SaveTransaction(Payment payment)
    {
        await _collection.InsertOneAsync(payment);
    }
}
