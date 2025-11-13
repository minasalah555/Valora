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

            // Seed admin role and user on startup
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var roleManager = services.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<ApplicationRole>>();
                    var userManager = services.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>>();

                    const string adminRole = "Admin";
                    const string adminEmail = "admin@local";
                    const string adminPassword = "Admin123!";

                    // Ensure role exists
                    var roleExists = roleManager.RoleExistsAsync(adminRole).GetAwaiter().GetResult();
                    if (!roleExists)
                    {
                        var r = new ApplicationRole { Name = adminRole };
                        roleManager.CreateAsync(r).GetAwaiter().GetResult();
                    }

                    // Ensure admin user exists
                    var adminUser = userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult();
                    if (adminUser == null)
                    {
                        adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                        var createResult = userManager.CreateAsync(adminUser, adminPassword).GetAwaiter().GetResult();
                        if (createResult.Succeeded)
                        {
                            userManager.AddToRoleAsync(adminUser, adminRole).GetAwaiter().GetResult();
                        }
                    }

                }
                catch
                {
                    // Swallow errors here to avoid preventing app startup; log if you want.
                }
            }

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
