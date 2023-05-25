using MediatR;

namespace HtmlBuilder.API.CQRS.Page.Add
{
    public class AddPageCommandRequest : IRequest<AddPageCommandResponse>
    {
        public string Name { get; set; }
    }
}
