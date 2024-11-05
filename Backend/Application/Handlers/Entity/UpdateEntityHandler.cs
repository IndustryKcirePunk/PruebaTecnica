using Domain.Interfaces.Services;
using Mapster;
using MediatR;

namespace Application.Handlers.Entity
{
    public record UpdateEntityCommand(Guid EntityId, string Name, string Description) : IRequest<bool>;

    public class UpdateEntityHandler : IRequestHandler<UpdateEntityCommand, bool>
    {
        private readonly IEntityService service;

        public UpdateEntityHandler(IEntityService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(UpdateEntityCommand request, CancellationToken cancellationToken)
        {
            return await service.Update(request.Adapt<Domain.Models.Entity>());
        }
    }
}
