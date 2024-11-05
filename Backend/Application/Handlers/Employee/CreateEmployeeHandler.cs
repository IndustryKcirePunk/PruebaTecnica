using Domain.Interfaces.Services;
using Mapster;
using MediatR;

namespace Application.Handlers.Employee
{
    public record CreateEmployeeWrapperCommand(CreateEmployeeCommand command) : IRequest<Domain.Models.Employee>;

    public record CreateEmployeeCommand(Guid EntityId, string FullName, string TypeIdentification, string Identification, string Phone, string Email);

    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeWrapperCommand, Domain.Models.Employee>
    {
        private readonly IEmployeeService service;

        public CreateEmployeeHandler(IEmployeeService service)
        {
            this.service = service;
        }

        public async Task<Domain.Models.Employee> Handle(CreateEmployeeWrapperCommand request, CancellationToken cancellationToken)
        {
            return await service.Create(request.command.Adapt<Domain.Models.Employee>());
        }
    }
}
