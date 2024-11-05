using Domain.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Employee
{
    public record GetEmployeeByEntityIdQuery(Guid entityId) : IRequest<List<Domain.Models.Employee>>;

    public class GetEmployeeByEntityIdHandler : IRequestHandler<GetEmployeeByEntityIdQuery, List<Domain.Models.Employee>>
    {
        private readonly IEmployeeService service;

        public GetEmployeeByEntityIdHandler(IEmployeeService service)
        {
            this.service = service;
        }

        public async Task<List<Domain.Models.Employee>> Handle(GetEmployeeByEntityIdQuery request, CancellationToken cancellationToken)
        {
            return await service.GetEmployeeByEntityId(request.entityId);
        }
    }
}
