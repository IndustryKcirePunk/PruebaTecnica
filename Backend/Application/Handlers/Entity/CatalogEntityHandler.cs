using Domain.Interfaces.Services;
using Domain.Query;
using Mapster;
using MediatR;

namespace Application.Handlers.Entity
{
    public record CatalogEntityQuery() : IRequest<List<CatalogEntityResponseQuery>>                                  ;


    public class CatalogEntityHandler : IRequestHandler<CatalogEntityQuery, List<CatalogEntityResponseQuery>>
    {
        private readonly IEntityService service;

        public CatalogEntityHandler(IEntityService service)
        {
            this.service = service;
        }

        public async Task<List<CatalogEntityResponseQuery>> Handle(CatalogEntityQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Models.Entity> entities = await service.GetAll();
            return entities.Adapt<List<CatalogEntityResponseQuery>>(); ;
        }
    }
}
