using Domain.Interfaces.Services;
using Mapster;
using MediatR;

namespace Application.Handlers.Employee
{
    public record UpdateEmployeeWrapperCommand(UpdateEmployeeCommand command) : IRequest<bool>;

    public record UpdateEmployeeCommand(Guid EmployeeId, Guid EntityId, string FullName, string TypeIdentification, string Identification, string Phone, string Email);

    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeWrapperCommand, bool>
    {
        private readonly IEmployeeService service;

        public UpdateEmployeeHandler(IEmployeeService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(UpdateEmployeeWrapperCommand request, CancellationToken cancellationToken)
        {
            return await service.Update(request.command.Adapt<Domain.Models.Employee>());
        }
    }
}
