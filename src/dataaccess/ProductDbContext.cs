using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dataaccess
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) :base(options)
        {
            if (!Products.Any())
            {
                Products.AddRange(new Product[]
                {
                    new Product{ Id = 1, Name = "Bread", Price = 2},
                    new Product{ Id = 2, Name = "Choclate", Price = 5}
                });
                SaveChanges();
            }
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductDbConfiguration());

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product{ Id = 1, Name = "Bread", Price = 2},
                new Product{ Id = 2, Name = "Choclate", Price = 5}
            });
        }
    }
}