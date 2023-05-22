using HtmlBuilder.API;
using HtmlBuilder.API.Configs;
using HtmlBuilder.API.Entities;
using HtmlBuilder.API.Infrastructure.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HtmlBuilder.API.CQRS.Auth.RefreshToken
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQueryRequest, RefreshTokenQueryResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtHelper _jwtHelper;
        private readonly JwtSettings _jwtSettings;

        public RefreshTokenQueryHandler(AppDbContext dbContext, UserManager<AppUser> userManager, IJwtHelper jwtHelper,
            IOptions<JwtSettings> jwtSettings)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _jwtHelper = jwtHelper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<RefreshTokenQueryResponse> Handle(RefreshTokenQueryRequest request,
            CancellationToken cancellationToken)
        {
            DateTime expireAt = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshTokenMinute);
            var refreshToken = await _dbContext.RefreshTokens.Where(x => x.Id.ToString() == request.RefreshToken &&
                                                                         x.ExpireAt >= expireAt).FirstOrDefaultAsync();

            if (refreshToken is null)
            {
                throw new Exception("Token geçerli değil.");
            }

            var user = await _userManager.FindByIdAsync(refreshToken.UserId);

            var token = _jwtHelper.CreateToken(user);

            var refreshTokenId = Guid.NewGuid();

            await _dbContext.RefreshTokens.AddAsync(new HtmlBuilder.API.Entities.RefreshToken
            {
                Id = refreshTokenId,
                UserId = user.Id,
                ExpireAt = expireAt,
                CreatedAt = DateTime.UtcNow
            });

            await _dbContext.SaveChangesAsync();

            return new()
            {
                Data = new Dictionary<string, object>()
                {
                    { "accessToken", token },
                    { "refreshToken", refreshTokenId.ToString() }
                }
            };
        }
    }
}