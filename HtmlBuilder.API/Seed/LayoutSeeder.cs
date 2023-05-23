using HtmlBuilder.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seed
{
    internal class LayoutSeeder : IEntityTypeConfiguration<Layout>
    {
        public void Configure(EntityTypeBuilder<Layout> builder)
        {
            builder.HasData(new List<Layout>()
            {
                new() { Styles = new List<string> { }, Scripts = new List<string> { "https://cdn.tailwindcss.com" } },
                new() { Styles = new List<string> { }, Scripts = new List<string> { "https://cdn.tailwindcss.com" } },
            });
        }
    }
}