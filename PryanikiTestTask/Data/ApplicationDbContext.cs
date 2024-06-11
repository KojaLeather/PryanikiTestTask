using Microsoft.EntityFrameworkCore;
using PryanikiTestTask.Data.Models;

namespace PryanikiTestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductOrder>().HasKey(k => new { k.OrderId, k.ProductId });

            modelBuilder.Entity<ProductOrder>().HasOne(o => o.Order).WithMany(m => m.ProductOrders).HasForeignKey(fk => fk.OrderId);

            modelBuilder.Entity<ProductOrder>().HasOne(o => o.Product).WithMany(m => m.ProductOrders).HasForeignKey(fk => fk.ProductId);
        }
    }
}
