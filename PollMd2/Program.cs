using Microsoft.EntityFrameworkCore;
using PollMd2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<pollmdContext>(options =>
    options.UseSqlServer("Server=ASPOSE\\SQLEXPRESS;Database=pollmd;Trusted_Connection=True;"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

//builder.Services.AddScoped<IRepository, MemoryRepository>();
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
