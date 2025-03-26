using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("B30C5B91-E13F-4062-B280-9342DF03455F"),
                FileName = "images/testimage",
                FileType = "jpg",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            new Image
            {
                Id = Guid.Parse("BB26BA2F-0403-4B31-8DDF-5E04B4CFADB7"),
                FileName = "images/javatest",
                FileType = "png",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            }
            );
        }
    }
}
