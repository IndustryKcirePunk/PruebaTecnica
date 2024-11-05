using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Employee> Create(Employee employee)
        {
            return await repository.Create(employee);
        }

        public async Task<bool> Delete(Guid employeeId)
        {
            return await repository.Delete(employeeId);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Employee> GetById(Guid employeeId)
        {
            return await repository.GetById(employeeId);
        }

        public async Task<List<Employee>> GetEmployeeByEntityId(Guid entityId)
        {
            return await repository.GetEmployeeByEntityId(entityId);
        }

        public async Task<bool> Update(Employee employee)
        {
            return await repository.Update(employee);
        }
    }
}
