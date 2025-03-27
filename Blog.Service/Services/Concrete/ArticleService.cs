using Blog.Data.UnitOfWorks;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Article>> GetAllArticleAsync()
        {
            return await unitOfWork.GetRepository<Article>().GetAllAsync();
        }
    }
}
