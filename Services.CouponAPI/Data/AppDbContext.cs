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
    {
    }
}
