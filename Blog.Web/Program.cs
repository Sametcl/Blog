using Blog.Data.Context;
using Blog.Data.Extensions;
using Blog.Entity.Entities;
using Blog.Service.Describers;
using Blog.Service.Extensions;
using Blog.Web.Filters.ArticleVisitors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);
builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.LoadServiceLayerExtensions();
builder.Services.AddSession();
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add<ArticleVisitorFilter>();
})
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass=ToastPositions.BottomRight,
        TimeOut=3000,
        ProgressBar=true,
    })
    .AddRazorRuntimeCompilation();

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "Blog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest//http https destekler
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute(); 
app.Run();
