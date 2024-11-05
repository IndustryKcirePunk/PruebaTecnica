using Domain.Models;
using Infrastructure.Config.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistences.Databases
{
    public class MongoDbManagement
    {
        public IMongoCollection<Entity> entityCollection;
        public IMongoCollection<Employee> employeeCollection;

        public MongoDbManagement(IOptions<MongoDbSettings> optionsMongoDb, IOptions<EntityStoreSettings> optionsEntity, IOptions<EmployeeStoreSettings> optionsEmployee)
        {
            var mongoClient = new MongoClient(optionsMongoDb.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(optionsMongoDb.Value.Database);
            entityCollection = mongoDatabase.GetCollection<Entity>(optionsEntity.Value.Collection);
            employeeCollection = mongoDatabase.GetCollection<Employee>(optionsEmployee.Value.Collection);
        }
    }
}
