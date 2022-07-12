using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataStore.EF
{
    public class BugsContext : DbContext
    {
        public BugsContext(DbContextOptions<BugsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);


            //  Seed Data

            modelBuilder.Entity<Project>()
                .HasData(
                    new Project { ProjectId = 1, Name = "Blog" },
                    new Project { ProjectId = 2, Name = "Portfolio" },
                    new Project { ProjectId = 3, Name = "Bug Tracker" }
                );
            modelBuilder.Entity<Ticket>()
                .HasData(
                    new Ticket { TicketId = 1, Title = "Bug 1", ProjectId = 1 },
                    new Ticket { TicketId = 2, Title = "Bug 2", ProjectId = 1 },
                    new Ticket { TicketId = 3, Title = "Bug 3", ProjectId = 2 }
                );

        }


        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}