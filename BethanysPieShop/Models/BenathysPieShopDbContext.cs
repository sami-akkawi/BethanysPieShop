using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class BenathysPieShopDbContext(DbContextOptions<BenathysPieShopDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Pie> Pies { get; set; }
}