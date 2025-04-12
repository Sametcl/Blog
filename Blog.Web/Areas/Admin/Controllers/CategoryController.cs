using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstraction;
using Blog.Service.Services.Concrete;
using Blog.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IToastNotification toast, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.validator = validator;
            this.toast = toast;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryAddDto);
                toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Islem Basarili" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            result.AddToModelState(ModelState);
            return View(categoryAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuid(categoryId);
            var map = mapper.Map<Category, CategoryUpdateDto>(category);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var map = mapper.Map<Category>(categoryUpdateDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                var name = await categoryService.UpdateCategoryAsync(categoryUpdateDto);
                toast.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "Islem Basarili" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            result.AddToModelState(ModelState);
            return View(categoryUpdateDto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var name= await categoryService.SafeDeleteCategoryAsync(categoryId);
            toast.AddSuccessToastMessage(Messages.Category.Delete(name), new ToastrOptions { Title = "Islem Basarili" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}
