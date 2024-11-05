using Domain.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Entity
{
    public record GetAllEntityQuery() : IRequest<List<Domain.Models.Entity>>;

    public class GetAllEntityHandler : IRequestHandler<GetAllEntityQuery, List<Domain.Models.Entity>>
    {
        private readonly IEntityService service;

        public GetAllEntityHandler(IEntityService service)
        {
            this.service = service;
        }

        public async Task<List<Domain.Models.Entity>> Handle(GetAllEntityQuery request, CancellationToken cancellationToken)
        {
            return await service.GetAll();
        }
    }
}
