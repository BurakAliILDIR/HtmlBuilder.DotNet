using MediatR;

namespace HtmlBuilder.API.CQRS.User.GetAll
{
    public class GetAllUserQueryRequest : IRequest<GetAllUserQueryResponse>
    {
    }
}