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
    internal class PageSeeder : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {

            builder.HasData(new List<Page>()
            {
                new() { LayoutId = Guid.NewGuid().ToString() , Name= "Home Page",  Html= "", Css = "", },
                new() { LayoutId = Guid.NewGuid().ToString() , Name= "About Page",  Html= "", Css = "", },
            }); ;
        }
    }
}
