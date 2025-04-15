using AutoMapper;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly RoleManager<AppRole> roleManager;

        public UserController(UserManager<AppUser> userManager, IMapper mapper,RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role =string.Join("", await userManager.GetRolesAsync(findUser));
                item.Role = role;
            }
            return View(map);
        }
    }
}
