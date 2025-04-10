using Blog.Core.Entities;
using Blog.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Image : EntityBase
    {
        public Image()
        {
            
        }
        public Image(string fileName, string fileType,string createBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreateBy = createBy;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string CreateBy { get; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
