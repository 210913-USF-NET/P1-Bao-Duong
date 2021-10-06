using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class InvincibleDBContext : DbContext
    {
        public InvincibleDBContext() { }

        public InvincibleDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
