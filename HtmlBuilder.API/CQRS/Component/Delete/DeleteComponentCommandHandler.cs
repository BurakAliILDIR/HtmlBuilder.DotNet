using HtmlBuilder.API.CQRS.Page.Add;
using MediatR;

namespace HtmlBuilder.API.CQRS.Component.Delete
{
    public class DeleteComponentCommandHandler : IRequestHandler<DeleteComponentCommandRequest, DeleteComponentCommandResponse>
    {
        private readonly AppDbContext _dbContext;

        public DeleteComponentCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DeleteComponentCommandResponse> Handle(DeleteComponentCommandRequest request, CancellationToken cancellationToken)
        {
            var component = await _dbContext.Components.FindAsync(request.Id);

            _dbContext.Components.Remove(component);

            await _dbContext.SaveChangesAsync();

            return new DeleteComponentCommandResponse { };
        }
    }
}
