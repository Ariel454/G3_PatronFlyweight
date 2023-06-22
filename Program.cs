using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using G3_PatronFlyweight.Data;
using G3_PatronFlyweight.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<G3_PatronFlyweightContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("G3_PatronFlyweightContext") ?? throw new InvalidOperationException("Connection string 'G3_PatronFlyweightContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ProductoFactory>();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
