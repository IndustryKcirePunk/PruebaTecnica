using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Task<Employee> GetById(Guid employeeId);
        public Task<List<Employee>> GetAll();
        public Task<List<Employee>> GetEmployeeByEntityId(Guid entityId);
        public Task<Employee> Create(Employee employee);
        public Task<bool> Update(Employee employee);
        public Task<bool> Delete(Guid employeeId);
    }
}
