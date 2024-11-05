using Domain.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Entity
{
    public record GetByIdEntityQuery(Guid entityId) : IRequest<Domain.Models.Entity>;

    public class GetByIdEntityHandler : IRequestHandler<GetByIdEntityQuery, Domain.Models.Entity>
    {
        private readonly IEntityService service;

        public GetByIdEntityHandler(IEntityService service)
        {
            this.service = service;
        }

        public async Task<Domain.Models.Entity> Handle(GetByIdEntityQuery request, CancellationToken cancellationToken)
        {
            return await service.GetById(request.entityId);
        }
    }
}
