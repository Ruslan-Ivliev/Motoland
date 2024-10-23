using Motoland.Models;
using Microsoft.EntityFrameworkCore;
using Motoland.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Dla MySQL użyj .UseMySql()

// Add services to the container.
builder.Services.AddControllersWithViews();


// Rejestracja serwisu IUserService z jego implementacją UserService
builder.Services.AddScoped<IUserService, UserService>(); // Możesz też użyć AddTransient lub AddSingleton

// Dodanie kontrolerów z widokami (MVC)
builder.Services.AddControllersWithViews();




var app = builder.Build();

void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IUserService, UserService>(); // Example for scoped lifetime
    // Other service registrations
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "Home",
        pattern: "{controller=Home}/{action=index}");

app.MapControllerRoute(
    name: "home",
    pattern: "{controller=Home}/{action=car_datails}"
    );

app.MapControllerRoute(
    name: "Home",
    pattern: "{controller=Account}/{action=Administrator}/{id?}");

app.MapControllerRoute(
    name: "Home",
    pattern: "{controller=Home}/{action=User_Login}/{id?}");


app.MapControllerRoute(
    name: "account",
    pattern: "{controller=AccountController}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "account",
    pattern: "{controller=AccountController}/{action=Register}/{id?}");
app.Run();
