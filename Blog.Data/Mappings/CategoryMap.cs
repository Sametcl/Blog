using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
            new Category
            {
                Id = Guid.Parse("BFE1A6E9-018D-4352-859E-C89B86BBBD45"),
                Name = "Asp.net Core",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
           new Category
           {
               Id = Guid.Parse("1AFE63D4-5D08-4CF9-8C0C-CFB9C1938DA2"),
               Name = "Java",
               CreatedBy = "Admin Test",
               CreatedDate = DateTime.Now,
               IsDeleted = false,
           });
        }
    }
}
