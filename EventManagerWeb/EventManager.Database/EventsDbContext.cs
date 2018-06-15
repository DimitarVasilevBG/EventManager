using EventManager.Database.DbModels;
using Microsoft.EntityFrameworkCore;
namespace EventManager.Database
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext() : base()
        {
            this.Database.Migrate();
        }

        public DbSet<EventDbModel> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventDbModel>()
                .HasKey(x => x.ID);
        }
    }
}
