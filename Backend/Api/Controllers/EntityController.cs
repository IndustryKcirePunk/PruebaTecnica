using Application.Handlers.Employee;
using Application.Handlers.Entity;
using Domain.Models;
using Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Entity>> GetAll() => await _mediator.Send(new GetAllEntityQuery());

        [HttpGet("{entityId}")]
        public async Task<Entity> GetAll(Guid entityId) => await _mediator.Send(new GetByIdEntityQuery(entityId));
        [HttpGet("Catalogs")]
        public async Task<List<CatalogEntityResponseQuery>> Catalogs() => await _mediator.Send(new CatalogEntityQuery());
        [HttpPost]
        public async Task<Entity> Create(CreateEntityCommand command) => await _mediator.Send(new CreateEntityCommand(command.Name, command.Description));
        [HttpPut]
        public async Task<bool> Update(UpdateEntityCommand command) => await _mediator.Send(new UpdateEntityCommand(command.EntityId, command.Name, command.Description));
        [HttpDelete("{entityId}")]
        public async Task<bool> Delete(Guid employeeId) => await _mediator.Send(new DeleteEmployeeCommand(employeeId));
    }
}
