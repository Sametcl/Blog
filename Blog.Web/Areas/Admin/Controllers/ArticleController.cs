using Blog.Entity.DTOs.Articles;
using Blog.Service.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;

        public ArticleController(IArticleService articleService,ICategoryService categoryService)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var article = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(article);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {   
            var categories=await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories=categories} );
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            await articleService.CreateArticleAsync(articleAddDto);
            return RedirectToAction("Index", "Article", new {Area="Admin"});
            //var categories = await categoryService.GetAllCategoriesNonDeleted();
            //return View(new ArticleAddDto { Categories = categories });
        }
    }
}
 