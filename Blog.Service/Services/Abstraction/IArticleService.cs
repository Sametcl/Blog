﻿using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstraction
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task CreateArticleAsync(ArticleAddDto articleAddDto);
    }
}
