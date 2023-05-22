using MediatR;

namespace HtmlBuilder.API.CQRS.Auth.ForgotPassword
{
    public class ForgotPasswordQueryRequest: IRequest<ForgotPasswordQueryResponse>
    {
        public required string UsernameOrEmail { get; set; }
    }
}
