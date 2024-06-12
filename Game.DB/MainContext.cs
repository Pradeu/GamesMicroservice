using Game.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Game.DB
{
    public class MainContext : DbContext
    {
        public MainContext()
        {

        }
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {

        }
        public DbSet<DbGame> Games { get; set; }
        public DbSet<DbGenre> Genres { get; set; }
        public DbSet<DbPlatform> Platforms { get; set; }
        public DbSet<DbEngine> Engines { get; set; }
        public DbSet<DbDeveloper> Developers { get; set; }
        public DbSet<DbUserList> UserLists { get; set; }
        public DbSet<DbUserStatus> GameStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbGame>()
                .HasMany(p => p.Genres)
                .WithMany(t => t.Games)
                .UsingEntity<GenreGame>(
                    "GenreGames",
                    p => p.HasOne(pt => pt.Genre).WithMany(e => e.GenreGames).HasForeignKey(e => e.GenreId),
                    t => t.HasOne(pt => pt.Game).WithMany(e => e.GenreGames).HasForeignKey(e => e.GameId),
                    j =>
                    {
                        j.HasKey(t => new { t.GenreId, t.GameId });
                    }
                );
            modelBuilder.Entity<DbGame>()
                .HasMany(p => p.Platforms)
                .WithMany(t => t.Games)
                .UsingEntity<PlatformGame>(
                    "PlatformGames",
                    p => p.HasOne(pt => pt.Platform).WithMany(e => e.PlatformGames).HasForeignKey(e => e.PlatformId),
                    t => t.HasOne(pt => pt.Game).WithMany(e => e.PlatformGames).HasForeignKey(e => e.GameId),
                    j =>
                    {
                        j.HasKey(t => new { t.PlatformId, t.GameId });
                    }
                );
            modelBuilder.Entity<DbGame>()
                .HasMany(p => p.Engines)
                .WithMany(t => t.Games)
                .UsingEntity<EngineGame>(
                    "EngineGames",
                    p => p.HasOne(pt => pt.Engine).WithMany(e => e.EngineGames).HasForeignKey(e => e.EngineId),
                    t => t.HasOne(pt => pt.Game).WithMany(e => e.EngineGames).HasForeignKey(e => e.GameId),
                    j =>
                    {
                        j.HasKey(t => new { t.EngineId, t.GameId });
                    }
                );
            modelBuilder.Entity<DbGame>()
                .HasMany(p => p.Developers)
                .WithMany(t => t.Games)
                .UsingEntity<DeveloperGame>(
                    "DeveloperGames",
                    p => p.HasOne(pt => pt.Developer).WithMany(e => e.DeveloperGames).HasForeignKey(e => e.DeveloperId),
                    t => t.HasOne(pt => pt.Game).WithMany(e => e.DeveloperGames).HasForeignKey(e => e.GameId),
                    j =>
                    {
                        j.HasKey(t => new { t.DeveloperId, t.GameId });
                    }
                );
            modelBuilder.Entity<DbUserList>()
                .HasOne(p => p.Game)
                .WithMany(t => t.UserLists)
                .HasForeignKey(p => p.GameId);
            modelBuilder.Entity<DbUserList>()
                .Property(j => j.StatusId).HasDefaultValue(1);
            modelBuilder.Entity<DbUserList>()
                .HasOne(p => p.UserStatus)
                .WithMany(t => t.UserLists)
                .HasForeignKey(p => p.StatusId);
            modelBuilder.Entity<DbGenre>();
            modelBuilder.Entity<DbPlatform>();
            modelBuilder.Entity<DbEngine>();
            modelBuilder.Entity<DbDeveloper>();
            modelBuilder.Entity<DbUserStatus>();
        }
    }
}
