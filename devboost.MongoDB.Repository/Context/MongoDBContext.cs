using devboost.MongoDB.Repository.Context.Interfaces;
using MongoDB.Driver;

namespace devboost.MongoDB.Repository.Context
{
    public class MongoDBContext : IMongoDBContext
    {
        readonly string _connectionString;
        readonly string _databaseName;

        public MongoDBContext(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;
        }

        public IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(_connectionString);
            var database = client.GetDatabase(_databaseName);
            return database;
        }
    }
}
