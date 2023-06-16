using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Product.InfraData.Data;

public class MongoDbContext : IMongoDbContext
{
    private IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration["MongoConnection"]);
        _database = mongoClient.GetDatabase("Mttechne");
    }

    public IMongoCollection<T> Collection<T>()
    {
        return _database.GetCollection<T>(typeof(T).Name);
    }
}
