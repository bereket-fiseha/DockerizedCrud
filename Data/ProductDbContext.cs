using DockerizedCrud.Models;
using Microsoft.EntityFrameworkCore;
namespace DockerizedCrud.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}