using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Persistences.Databases;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Persistences.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MongoDbManagement _mongoDbManagement;

        public EmployeeRepository(MongoDbManagement mongoDbManagement)
        {
            _mongoDbManagement = mongoDbManagement;
        }

        public async Task<Employee> Create(Employee employee)
        {
            await _mongoDbManagement.employeeCollection.InsertOneAsync(employee);
            return employee;
        }

        public async Task<bool> Delete(Guid EmployeeId)
        {
            var result = await _mongoDbManagement.employeeCollection.DeleteOneAsync(e => e.EmployeeId.Equals(EmployeeId));
            return result.DeletedCount > 0;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _mongoDbManagement.employeeCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Employee> GetById(Guid EmployeeId)
        {
            return await _mongoDbManagement.employeeCollection.Find(e => e.EmployeeId.Equals(EmployeeId)).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmployeeByEntityId(Guid entityId)
        {
            return await _mongoDbManagement.employeeCollection.Find(x => x.EntityId.Equals(entityId)).ToListAsync();
        }

        public async Task<bool> Update(Employee employee)
        {
            var result = await _mongoDbManagement.employeeCollection.ReplaceOneAsync(e => e.EmployeeId.Equals(employee.EmployeeId), employee);
            return result.ModifiedCount > 0;
        }
    }
}
