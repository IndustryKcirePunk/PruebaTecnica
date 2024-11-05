using Domain.Interfaces.Services;
using Mapster;
using MediatR;

namespace Application.Handlers.Entity
{
    public record CreateEntityCommand(string Name, string Description) : IRequest<Domain.Models.Entity>;

    public class CreateEntityHandler : IRequestHandler<CreateEntityCommand, Domain.Models.Entity>
    {
        private readonly IEntityService service;

        public CreateEntityHandler(IEntityService service)
        {
            this.service = service;
        }

        public async Task<Domain.Models.Entity> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            return await service.Create(request.Adapt<Domain.Models.Entity>());
        }
    }
}
