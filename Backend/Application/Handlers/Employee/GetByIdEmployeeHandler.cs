using Domain.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Employee
{
    public record GetByIdEmployeeQuery(Guid employeeId): IRequest<Domain.Models.Employee>;

    public class GetByIdEmployeeHandler : IRequestHandler<GetByIdEmployeeQuery, Domain.Models.Employee>
    {
        private readonly IEmployeeService service;

        public GetByIdEmployeeHandler(IEmployeeService service)
        {
            this.service = service;
        }

        public async Task<Domain.Models.Employee> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await service.GetById(request.employeeId);
        }
    }
}
