using HtmlBuilder.API.Entities;

namespace HtmlBuilder.API.Infrastructure.Jwt
{
    public interface IJwtHelper
    {
        string CreateToken(AppUser user);
    }
}
