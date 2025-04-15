using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class AppUser :IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("BB26BA2F-0403-4B31-8DDF-5E04B4CFADB7");
        public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
