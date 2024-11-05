using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IEntityService
    {
        public Task<Entity> GetById(Guid entityId);
        public Task<List<Entity>> GetAll();
        public Task<Domain.Models.Entity> Create(Entity entity);
        public Task<bool> Update(Entity entity);
        public Task<bool> Delete(Guid entityId);
    }
}
