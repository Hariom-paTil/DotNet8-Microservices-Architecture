using Microsoft.EntityFrameworkCore;
using Services.CouponAPI.Models;

namespace Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }



        // this method is used to seed data into the database when the 
        // application is first run. It is called when the database is created and the model is being built.

        // The HasData method is used to specify the data that should be seeded into the database.
        // In this case, we are seeding two Coupon objects with their properties set to specific values.
        // SeedDatbase is a method that is called when the database is created and the model is being built. It is used to seed data into the database when the application is first run.

        // SimplyMeans :: we create table and add some data to it when the application is first run. This is useful for testing and development purposes.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    CouponId = 1,
                    CouponCode = "DISCOUNT10",
                    DiscountAmount = 10.0,
                    MinAmount = 50
                },
                new Coupon
                {
                    CouponId = 2,
                    CouponCode = "DISCOUNT20",
                    DiscountAmount = 20.0,
                    MinAmount = 100
                }
            );
        }
    }
}
