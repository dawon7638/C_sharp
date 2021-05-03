using Microsoft.EntityFrameworkCore;

namespace prodCat.Models
{
    public class prodCatContext : DbContext
    {
        public prodCatContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Association> Associations { get; set; }
    }
}