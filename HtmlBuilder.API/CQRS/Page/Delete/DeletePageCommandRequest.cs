using MediatR;

namespace HtmlBuilder.API.CQRS.Page.Delete
{
    public class DeletePageCommandRequest : IRequest<DeletePageCommandResponse>
    {
        public string Id { get; set; }
    }
}
