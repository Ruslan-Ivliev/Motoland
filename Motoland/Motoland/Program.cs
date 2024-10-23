using Motoland.Models;
using Microsoft.EntityFrameworkCore;
using Motoland.Services;
using CarAdApp.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the DB context
builder.Services.AddDbContext<CarAdDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Konfiguracja połączenia z bazą danych (SQL Server lub MySQL)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Dla MySQL użyj .UseMySql() z odpowiednią wersją serwera MySQL

// Dodanie kontrolerów z widokami (MVC)
builder.Services.AddControllersWithViews();

// Rejestracja serwisu IUserService z jego implementacją UserService
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Inicjalizacja konta administratora przy starcie aplikacji
using (var scope = app.Services.CreateScope())
{
    var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
    userService.CreateAdminIfNotExists(); // Sprawdzenie i utworzenie admina, jeśli nie istnieje
}

// Konfiguracja pipeline'u HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Mapowanie tras
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "car_details",
    pattern: "{controller=Home}/{action=Car_Details}/{id?}");

app.MapControllerRoute(
    name: "admin_panel",
    pattern: "{controller=Account}/{action=Administrator}/{id?}");

app.MapControllerRoute(
    name: "user_login",
    pattern: "{controller=CarAds}/{action=User_Login}/{id?}");

app.MapControllerRoute(
    name: "account_login",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "account_register",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CarAds}/{action=Create}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CarAds}/{action=Edit}/{id?}");

app.Run();
