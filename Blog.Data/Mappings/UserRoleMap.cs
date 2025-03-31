using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {

            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("956073A7-DC08-4F32-A7B9-CCDCE660D523"),
                RoleId= Guid.Parse("C39CA640-E96C-453F-B2E6-437ACC3E40E8"),
            },
            new AppUserRole
            {
                UserId= Guid.Parse("734B1748-E3E6-4BD9-8024-60E44D3DB7D9"),
                RoleId = Guid.Parse("BB073D1F-7802-4E12-8627-378EF113ECF9"),
            }
            );
        }
    }
}
