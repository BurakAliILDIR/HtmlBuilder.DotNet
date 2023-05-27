using MediatR;

namespace HtmlBuilder.API.CQRS.Component.Add
{
    public class AddComponentCommandRequest : IRequest<AddComponentCommandResponse>
    {
        public string Label { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
    }
}
