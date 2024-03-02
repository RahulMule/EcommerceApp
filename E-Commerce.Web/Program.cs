using E_Commerce.Web.Data;
using E_Commerce.Web.Services;
using E_Commerce.Web.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
string conn = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(conn));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHttpClient<IProductService, ProductService>( c => c.BaseAddress = new Uri("https://rahulwebappproduct.azurewebsites.net/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
