using Domain.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Entity
{
    public record DeleteEntityCommand(Guid entityId) : IRequest<bool>;

    public class DeleteEntityHandler : IRequestHandler<DeleteEntityCommand, bool>
    {
        private readonly IEntityService service;

        public DeleteEntityHandler(IEntityService service)
        {
            this.service = service;
        }

        public async Task<bool> Handle(DeleteEntityCommand request, CancellationToken cancellationToken)
        {
            return await service.Delete(request.entityId);
        }
    }
}
