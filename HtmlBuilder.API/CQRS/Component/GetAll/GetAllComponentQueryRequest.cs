using HtmlBuilder.API.CQRS.User.GetAll;
using MediatR;

namespace HtmlBuilder.API.CQRS.Component.GetAll
{
    public class GetAllComponentQueryRequest : IRequest<GetAllComponentQueryResponse>
    {
    }
}
