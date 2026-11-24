using InventoryManagement.Models;//model class use kora hoyese
using Microsoft.EntityFrameworkCore;//ef core er necessery class
namespace InventoryManagement.Data;//class data framework er ontorbukto



public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
     : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}