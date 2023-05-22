﻿using Microsoft.EntityFrameworkCore;

namespace HtmlBuilder.API.Extensions
{
    public static class DbExtension
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("PostgreSQL"));
            });

        }
    }
}