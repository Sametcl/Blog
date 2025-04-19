using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya sifreniz hatali");
                        return View(userLoginDto);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya sifreniz hatali");
                    return View(userLoginDto);
                }
            }
            else
            {
                return View(userLoginDto);
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [Authorize]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
