using Microsoft.EntityFrameworkCore;
using ArtWebApi.Models;

namespace ArtWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Gallery)
                .WithMany(g => g.Artists)
                .HasForeignKey(a => a.GalleryId);
            
                    modelBuilder.Entity<Gallery>().HasData(
            new Gallery { GalleryId = 1, Name = "Gallery 1" },
            new Gallery { GalleryId = 2, Name = "Gallery 2" }
        );

        modelBuilder.Entity<Artist>().HasData(
            new Artist { ArtistId = 1, Name = "Artist 1", GalleryId = 1 },
            new Artist { ArtistId = 2, Name = "Artist 2", GalleryId = 1 },
            new Artist { ArtistId = 3, Name = "Artist 3", GalleryId = 2 }
        );

        }
    }
}
