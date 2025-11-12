using Microsoft.EntityFrameworkCore;
using Valora.Data;
using Valora.Models;
using Valora.Repositories;
using Valora.Services;

namespace Valora
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                //options.Password.RequiredLength = 6;
                //options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<Context>();
            // Application repositories & services registrations
            builder.Services.AddScoped<ICartServices, CartServices>();
            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<OrderService>();
            // Review repository & service
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<ReviewService>();
            // Product and Category services (used by controllers/views)
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            // CategoryServices does not implement ICategoryServices in this codebase, register concrete type
            builder.Services.AddScoped<CategoryServices>();


            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ITI_DB"));

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
