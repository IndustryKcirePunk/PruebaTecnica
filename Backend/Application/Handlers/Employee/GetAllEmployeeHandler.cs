using Domain.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Employee
{
    public record GetAllEmployeeQuery() : IRequest<List<Domain.Models.Employee>>;

    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, List<Domain.Models.Employee>>
    {
        private readonly IEmployeeService service;

        public GetAllEmployeeHandler(IEmployeeService service)
        {
            this.service = service;
        }

        public async Task<List<Domain.Models.Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await service.GetAll();
        }
    }
}
