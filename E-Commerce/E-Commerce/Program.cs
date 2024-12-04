using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add Database Services
builder.Services.AddDbContext<AppDbContext>(
    Options =>Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Add Session Services
builder.Services.AddSession(
    Options =>
    {
        Options.IdleTimeout = TimeSpan.FromSeconds(3);
    }
    );

builder.Services.AddSingleton<EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Public}/{action=Index}/{id?}");

app.Run();
