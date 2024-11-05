using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Persistences.Databases;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Persistences.Repositories
{
    internal class EntityRepository : IEntityRepository
    {
        private readonly MongoDbManagement _mongoDbManagement;

        public EntityRepository(MongoDbManagement mongoDbManagement)
        {
            _mongoDbManagement = mongoDbManagement;
        }

        public async Task<Entity> Create(Entity entity)
        {
            await _mongoDbManagement.entityCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(Guid entityId)
        {
            var result = await _mongoDbManagement.entityCollection.DeleteOneAsync(e => e.EntityId.Equals(entityId));
            return result.DeletedCount > 0;
        }

        public async Task<List<Entity>> GetAll()
        {
            return await _mongoDbManagement.entityCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Entity> GetById(Guid entityId)
        {
            return await _mongoDbManagement.entityCollection.Find(e => e.EntityId.Equals(entityId)).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Entity entity)
        {
            var result = await _mongoDbManagement.entityCollection.ReplaceOneAsync(e => e.EntityId.Equals(entity.EntityId), entity);
            return result.ModifiedCount > 0;
        }
    }
}
