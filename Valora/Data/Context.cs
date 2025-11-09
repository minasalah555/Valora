using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;
using Valora.Models;

namespace Valora.Data
{
    public class Context:IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public Context(DbContextOptions<Context> options ):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
         public DbSet<CartItem> CartItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                 .EnableSensitiveDataLogging(true);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>().HasNoKey();
            builder.Entity<IdentityUserToken<string>>().HasNoKey();

            //modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });
            });
        }

    }
}
