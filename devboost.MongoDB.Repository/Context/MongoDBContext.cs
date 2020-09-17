using devboost.MongoDB.Repository.Context.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IMongoDatabase Database
        {
            get
            {
                var client = new MongoClient(_connectionString);
                var database = client.GetDatabase(_databaseName);
                return database;
            }
        }
    }
}
