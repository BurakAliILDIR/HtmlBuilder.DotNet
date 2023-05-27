using HtmlBuilder.API.CQRS.Page.Add;
using MediatR;

namespace HtmlBuilder.API.CQRS.Page.Delete
{
    public class DeletePageCommandHandler : IRequestHandler<DeletePageCommandRequest, DeletePageCommandResponse>
    {
        private readonly AppDbContext _dbContext;

        public DeletePageCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DeletePageCommandResponse> Handle(DeletePageCommandRequest request, CancellationToken cancellationToken)
        {
            var page = await _dbContext.Pages.FindAsync(request.Id);

            _dbContext.Pages.Remove(page);

            await _dbContext.SaveChangesAsync();

            return new DeletePageCommandResponse { };
        }
    }
}
