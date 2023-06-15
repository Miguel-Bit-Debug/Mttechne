using MongoDB.Driver;

namespace Product.InfraData.Data
{
    public interface IMongoDbContext : IDisposable
    {
        IMongoCollection<T> Collection<T>();
    }
}