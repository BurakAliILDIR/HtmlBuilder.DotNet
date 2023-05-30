using MediatR;

namespace HtmlBuilder.API.CQRS.Component.Add
{
    public class AddComponentCommandHandler : IRequestHandler<AddComponentCommandRequest, AddComponentCommandResponse>
    {
        private readonly AppDbContext _dbContext;

        public AddComponentCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddComponentCommandResponse> Handle(AddComponentCommandRequest request, CancellationToken cancellationToken)
        {
            var component = new Entities.Component()
            {
                Label = request.Label,
                Category = request.Category,
                Content = request.Content
            };

            _dbContext.Components.Add(component);

            await _dbContext.SaveChangesAsync();

            return new AddComponentCommandResponse { };
        }
    }
}
