using Microsoft.EntityFrameworkCore;

namespace ActivityCtr.Models
{
    public class ActivityCtrContext: DbContext
    {
        public ActivityCtrContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }

    }
}