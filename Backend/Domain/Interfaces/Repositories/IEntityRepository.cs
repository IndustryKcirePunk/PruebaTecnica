using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IEntityRepository
    {
        public Task<Entity> GetById(Guid EntityId);
        public Task<List<Entity>> GetAll();
        public Task<Entity> Create(Entity Entity);
        public Task<bool> Update(Entity Entity);
        public Task<bool> Delete(Guid EntityId);
    }
}
