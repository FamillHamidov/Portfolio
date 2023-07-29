using BusinessLayer;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IAboutDal, EfAboutService>();
builder.Services.AddScoped<IAboutService,AboutManager>();
builder.Services.AddScoped<ISkillDal, EfSkillService>();
builder.Services.AddScoped<ISkillService, SkillManager>();
builder.Services.AddScoped<IEducationDal, EfEducationService>();
builder.Services.AddScoped<IEducationService, EducationManager>();
builder.Services.AddScoped<IExperienceDal, EfExperienceService>();
builder.Services.AddScoped<IExperienceService, ExperienceManager>();
builder.Services.AddScoped<IPortfolioDal, EfPortfolioService>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();
builder.Services.AddIdentity<AdminUser, AdminRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy));

});
builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
	options.LoginPath = "/Admin/Login/SignIn/";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
