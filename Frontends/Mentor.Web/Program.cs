using FluentValidation.AspNetCore;
using Mentor.Shared.Services;
using Mentor.Web.Extensions;
using Mentor.Web.Handler;
using Mentor.Web.Helpers;
using Mentor.Web.Models;
using Mentor.Web.Validators;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));

builder.Services.AddSingleton<PhotoHelper>();

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

builder.Services.AddHttpClientServices(builder);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Auth/SignIn";
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
    opt.Cookie.Name = "mentorcookie";
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddAccessTokenManagement();

builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CourseCreateInputValidator>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
