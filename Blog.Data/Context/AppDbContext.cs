using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blog.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>

    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Article>().Property(x=>x.Title).HasMaxLength(50); bu kullanim clean bir yapi sunmuyor bu nedenle mapping klasoru altinda topluyoruz bu bilgileri 
            //builder.ApplyConfiguration(new ArticleMap()); bu sekilde bir kullanim saglarsak tum map islerini tek tek eklemeiz lazim 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//bu kullanim tum mapping configuration islerini aliyor dogru kullanim
            //Assembly == bulundugu katmanin adi "blog.data" diye dusunebiliriz
        }
    }
}
