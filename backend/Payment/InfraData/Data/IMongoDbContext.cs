using MongoDB.Driver;

namespace Product.InfraData.Data
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> Collection<T>();
    }
}