using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<Employee> GetById(Guid EmployeeId);
        public Task<List<Employee>> GetAll();
        public Task<List<Employee>> GetEmployeeByEntityId(Guid entityId);
        public Task<Employee> Create(Employee employee);
        public Task<bool> Update(Employee employee);
        public Task<bool> Delete(Guid Employee);
    }
}
