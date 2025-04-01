using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.net Core Deneme Makalesi 1",
                Content = "Asp.net Core Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n",
                ViewCount = 15,        
                CategoryId= Guid.Parse("BFE1A6E9-018D-4352-859E-C89B86BBBD45"),
                ImageId= Guid.Parse("B30C5B91-E13F-4062-B280-9342DF03455F"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId= Guid.Parse("956073A7-DC08-4F32-A7B9-CCDCE660D523"),
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Java Deneme Makalesi 1",
                Content = "Java Deneme Praesent placerat, magna in vehicula vestibulum, felis urna cursus lorem, sed vestibulum quam eros vel libero. Vivamus commodo, odio sed fringilla pretium, sem nulla feugiat odio, in cursus elit dolor et ex.\r\n",
                ViewCount = 15,
                CategoryId = Guid.Parse("1AFE63D4-5D08-4CF9-8C0C-CFB9C1938DA2"),
                ImageId = Guid.Parse("BB26BA2F-0403-4B31-8DDF-5E04B4CFADB7"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId= Guid.Parse("734B1748-E3E6-4BD9-8024-60E44D3DB7D9"),
            }
           );
        }
    }
}
