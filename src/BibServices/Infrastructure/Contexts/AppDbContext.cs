using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Club> Clubs { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration.GetValue<string>("PostgreSQL:ConnectionString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClubConfig());
        }

        /// <summary>
        /// Supporting default and global controls for Audit events (dates and edits)
        /// TODO: user info needs to be added!
        /// </summary>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "Unknown";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "Unknown";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
}