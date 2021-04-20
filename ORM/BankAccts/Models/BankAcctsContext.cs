using Microsoft.EntityFrameworkCore;

namespace BankAccts.Models
{
    public class BankAcctsContext: DbContext
    {
        public BankAcctsContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        // public DbSet<Widget> Widgets { get; set; }
        // public DbSet<Item> Items { get; set; }
    }

}
