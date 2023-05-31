using BookstoreApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

builder.Services.AddSession();

var connStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlite(connStr));

builder.Services.AddScoped<IBook, DbBookRepo>();
//builder.Services.AddScoped<IBook, InMemoryBookRepo>();

var app = builder.Build();

CustomData.SeedData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//Seed Data
app.UseSession();
GlobalData.SeedData();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
