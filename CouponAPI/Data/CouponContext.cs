using CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CouponAPI.Data
{
    public class CouponContext : DbContext
    {
        public CouponContext()
        {

        }
        public CouponContext(DbContextOptions<CouponContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        public DbSet<Coupon> Coupons { get; set; } = null!;
    }
}
