using MediatR;

namespace HtmlBuilder.API.CQRS.Page.Find;

public class FindPageQueryRequest : IRequest<FindPageQueryResponse>
{
    public string Id { get; set; }
}