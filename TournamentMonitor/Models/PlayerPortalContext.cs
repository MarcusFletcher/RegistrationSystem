using Microsoft.EntityFrameworkCore;
using System.Linq;
using TournamentMonitor.Models.RegistrationTables;

namespace TournamentMonitor.Models
{
    public class PlayerPortalContext : DbContext
    {

        public PlayerPortalContext(DbContextOptions<PlayerPortalContext> options)
            : base(options)

        {

        }

        //RegistrationTables
        public DbSet<TournamentType> TournamentTypes { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DivisionDetail> DivisionDetails { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RegistrationStatus> RegistrationStatuses { get; set; }
        public DbSet<TournamentRegistration> TournamentRegistrations { get; set; }
        public DbSet<Venue> Venues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>();
            //Composite Key 
            modelBuilder.Entity<TournamentRegistration>()
                .HasKey(c => new { c.TournamentID, c.PlayerID });

           
        }
    }
}