using HtmlBuilder.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HtmlBuilder.API
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}