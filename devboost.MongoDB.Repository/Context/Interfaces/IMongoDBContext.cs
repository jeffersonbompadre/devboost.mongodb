using MongoDB.Driver;

namespace devboost.MongoDB.Repository.Context.Interfaces
{
    public interface IMongoDBContext
    {
        IMongoDatabase GetDatabase();
    }
}
