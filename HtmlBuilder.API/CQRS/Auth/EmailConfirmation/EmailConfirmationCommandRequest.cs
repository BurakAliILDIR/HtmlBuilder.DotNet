using MediatR;

namespace HtmlBuilder.API.CQRS.Auth.EmailConfirmation
{
    public class EmailConfirmationCommandRequest : IRequest<EmailConfirmationCommandResponse>
    {
        public required string UserId { get; set; }
        public required string Token { get; set; }
    }
}