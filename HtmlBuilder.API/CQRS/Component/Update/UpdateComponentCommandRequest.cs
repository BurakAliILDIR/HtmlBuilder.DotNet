using MediatR;

namespace HtmlBuilder.API.CQRS.Component.Update
{
    public class UpdateComponentCommandRequest : IRequest<UpdateComponentCommandResponse>
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
    }
}
