using Application.Handlers.Employee;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Employee>> GetAll() => await _mediator.Send(new GetAllEmployeeQuery());
        [HttpGet("{entityId}/Entity")]
        public async Task<List<Employee>> GetEmployeeByEntityId(Guid entityId) => await _mediator.Send(new GetEmployeeByEntityIdQuery(entityId));
        [HttpGet("{employeeId}")]
        public async Task<Employee> GetAll(Guid employeeId) => await _mediator.Send(new GetByIdEmployeeQuery(employeeId));
        [HttpPost]
        public async Task<Employee> Create(CreateEmployeeCommand command) => await _mediator.Send(new CreateEmployeeWrapperCommand(command));
        [HttpPut]
        public async Task<bool> Update(UpdateEmployeeCommand command) => await _mediator.Send(new UpdateEmployeeWrapperCommand(command));
        [HttpDelete("{employeeId}")]
        public async Task<bool> Delete(Guid employeeId) => await _mediator.Send(new DeleteEmployeeCommand(employeeId));

    }
}
