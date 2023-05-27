using MediatR;

namespace HtmlBuilder.API.CQRS.Component.Find;

public class FindComponentQueryRequest : IRequest<FindComponentQueryResponse>
{
    public string Id { get; set; }
}