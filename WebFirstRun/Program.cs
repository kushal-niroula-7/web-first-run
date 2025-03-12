using Microsoft.EntityFrameworkCore;
using WebFirstRun.Data;
using WebFirstRun.Services;
using WebFirstRun.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// ConfigureServices
// DI, Auth, CORS

builder.Services.AddDbContext<FirstRunDbContext>(builder => {
    builder.UseNpgsql("Host=localhost;Database=first_run;Username=postgres;Password=admin");
});


// Add a service to service container as Scoped
// When I ask for `IProductService` give me object of `ProductService`
builder.Services.AddScoped<IProductService, ProductService>();
// Creates a dependency graph


var app = builder.Build();

// Configure HTTP Pipeline

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

// app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
