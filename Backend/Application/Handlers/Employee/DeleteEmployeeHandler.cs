using Domain.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Employee
{
    public record DeleteEmployeeCommand(Guid employeeId) : IRequest<bool>;

    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeService service;

        public DeleteEmployeeHandler(IEmployeeService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await service.Delete(request.employeeId);
        }
    }
}
