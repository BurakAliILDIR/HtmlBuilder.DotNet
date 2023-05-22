using HtmlBuilder.API.Entities;

namespace HtmlBuilder.API.Infrastructure.Mail
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailData mailData, CancellationToken ct);
    }
}
