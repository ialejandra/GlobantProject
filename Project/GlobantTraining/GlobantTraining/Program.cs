using Microsoft.EntityFrameworkCore;
using GlobantTraining.DAL;
using GlobantTraining.Business.Abstract;
using GlobantTraining.Business.Business;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("GlobantTrainingContext"))
);

builder.Services.AddScoped <IConsumableBusiness, ConsumableBusiness>();
builder.Services.AddScoped<ITypeProductBusiness, TypeProductBusiness>();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
