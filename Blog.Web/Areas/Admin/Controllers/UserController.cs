using AutoMapper;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NToastNotify;
using System.Data;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IValidator<AppUser> validator;
        private readonly IToastNotification toast;

        public UserController(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IValidator<AppUser> validator, IToastNotification toast)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.validator = validator;
            this.toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));
                item.Role = role;
            }
            return View(map);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(new UserAddDto
            {
                Roles = roles
            });
        }


        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await roleManager.Roles.ToListAsync();
            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;
                var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await userManager.AddToRoleAsync(map, findRole.ToString());
                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Islem Basarili" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto
                    {
                        Roles = roles
                    });
                }
            }
            return View(new UserAddDto
            {
                Roles = roles
            });
        }



        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var roles = await roleManager.Roles.ToListAsync();

            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;

            var userRoles = await userManager.GetRolesAsync(user);
            var userRole = userRoles.FirstOrDefault();

            if (userRole != null)
            {
                var role = await roleManager.FindByNameAsync(userRole);
                map.RoleId = role.Id;
            }

            return View(map);
        }



        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());

            if (user != null)
            {
                var userRole = string.Join("", await userManager.GetRolesAsync(user));
                var roles = await roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await validator.ValidateAsync(map);
                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            await userManager.RemoveFromRoleAsync(user, userRole);
                            var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                            await userManager.AddToRoleAsync(user, findRole.Name);
                            toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Islem Basarili" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDto
                            {
                                Roles = roles
                            });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto
                        {
                            Roles = roles
                        });
                    }

                }
            }
            return NotFound();
        }



        [HttpGet]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Islem Basarili" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }




        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var map = mapper.Map<UserProfileDto>(user);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var isVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
                if (isVerified && userProfileDto.NewPassword != null)
                {
                    var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await userManager.UpdateSecurityStampAsync(user);
                        await signInManager.SignOutAsync();
                        await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);
                        user.FirstName = userProfileDto.FirstName;
                        user.LastName = userProfileDto.LastName;
                        user.PhoneNumber = userProfileDto.PhoneNumber;

                        await userManager.UpdateAsync(user);
                        toast.AddSuccessToastMessage("Sifreniz ve bilgileriniz basariyla degistirilmistir");
                        return View();

                    }
                    else
                    {
                        result.AddToIdentityModelState(ModelState);
                        return View();
                    }
                }
                else if (isVerified)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    user.FirstName = userProfileDto.FirstName;
                    user.LastName = userProfileDto.LastName;
                    user.PhoneNumber = userProfileDto.PhoneNumber;
                    await userManager.UpdateAsync(user);
                    toast.AddSuccessToastMessage("Bilgileriniz basariyla degistirilmistir");
                    return View();
                }
                else
                {
                    toast.AddErrorToastMessage("Bilgileriniz guncellenirken bir hata olustu!");
                    return View();
                }
            }
            return View();
        }
    }
}
