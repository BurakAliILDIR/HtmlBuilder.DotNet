using MediatR;

namespace HtmlBuilder.API.CQRS.Auth.RefreshToken
{
    public class RefreshTokenQueryRequest: IRequest<RefreshTokenQueryResponse>
    {
        public string RefreshToken { get; set; }
    }
}
