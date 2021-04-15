using Microsoft.EntityFrameworkCore;


namespace CRUD_Delicious.Models
{
    public class CRUD_DeliciousContext : DbContext
    {
        public CRUD_DeliciousContext(DbContextOptions options) : base(options) { }



        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<DishModel> Dishes { get; set; }

        // public DbSet<Widget> Widgets { get; set; }
        // public DbSet<Item> Items { get; set; }
    }
}

