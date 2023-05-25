using HtmlBuilder.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HtmlBuilder.API
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }
    }
}