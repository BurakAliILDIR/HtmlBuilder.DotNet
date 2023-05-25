using HtmlBuilder.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlBuilder.Repository.Seed
{
    public class PageSeeder : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {

            builder.HasData(new List<Page>()
            {
                new() { Name= "Home Page",  Html= "", Css = "", },
                new() { Name= "About Page",  Html= "", Css = "", },
            }); ;
        }
    }
}
