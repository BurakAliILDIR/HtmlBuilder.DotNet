using MediatR;

namespace HtmlBuilder.API.CQRS.Component.Delete
{
    public class DeleteComponentCommandRequest : IRequest<DeleteComponentCommandResponse>
    {
        public string Id { get; set; }
    }
}
