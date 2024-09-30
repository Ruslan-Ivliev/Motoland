using Motoland.Models;

var builder = WebApplication.CreateBuilder(args);

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "account",
    pattern: "{controller=AccountController}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "account",
    pattern: "{controller=AccountController}/{action=Register}/{id?}");
app.Run();
