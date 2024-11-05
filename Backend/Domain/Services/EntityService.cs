using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository repository;

        public EntityService(IEntityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Entity> Create(Entity entity)
        {
            return await repository.Create(entity);
        }

        public async Task<bool> Delete(Guid entityId)
        {
            return await repository.Delete(entityId);
        }

        public async Task<List<Entity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Entity> GetById(Guid entityId)
        {
            return await repository.GetById(entityId);
        }

        public async Task<bool> Update(Entity entity)
        {
            return await repository.Update(entity);
        }
    }
}
