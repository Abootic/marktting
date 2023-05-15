using Base.Common.Interface;
using Base.Extensions;
using markettng.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
var configraution = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICurrentUserServices, CurrentUserServices>();
builder.Services.AddPresistence(configraution);
builder.Services.ConfigureApplicationCookie(builder =>
{
    builder.LoginPath = "/UserAccess/Login";
    builder.LoginPath = "/UserAccess/Logout";
    builder.AccessDeniedPath = "/Account/AccessDenaid";
    builder.SlidingExpiration = true;
    
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
// options.EventsType = typeof(CookieAuthenticationEvents);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
   pattern: "{controller=Home}/{action=Index}");
//  pattern: "{controller=UserAccess}/{action=Login}");

app.Run();
