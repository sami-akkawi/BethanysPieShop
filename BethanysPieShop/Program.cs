using System.Text.Json.Serialization;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BethanysPieShopDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:BenthanyPieShopDbContextConnection"]));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// required for API services, not needed here because AddControllersWithViews is used
// builder.Services.AddControllers();

// add own services
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(ShoppingCart.GetCart);
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

WebApplication app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// required for API, not needed here because we use MapDefaultControllerRoute
// app.MapControllers();

app.UseAntiforgery();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapRazorComponents<WebApplication>()
    .AddInteractiveServerRenderMode();

DbInitializer.Seed(app);

app.Run();