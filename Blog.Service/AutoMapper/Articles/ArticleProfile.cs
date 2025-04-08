using AutoMapper;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;

namespace Blog.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto,Article>().ReverseMap();
            CreateMap<ArticleUpdateDto,Article>().ReverseMap();
            CreateMap<ArticleUpdateDto,ArticleDto>().ReverseMap();
            CreateMap<ArticleAddDto,Article>().ReverseMap();
        }
    }
}
