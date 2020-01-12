using Evt.Test.Model;
using Microsoft.EntityFrameworkCore;

namespace Evt.Test.Data
{
    public class EvtContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Database/evt.db");
        }
    }
}
