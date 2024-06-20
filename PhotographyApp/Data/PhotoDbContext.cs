using Microsoft.EntityFrameworkCore;
using PhotoApp.Models;

namespace PhotoApp.Data
{
    public class PhotoDbContext : DbContext
    {
        public PhotoDbContext(DbContextOptions<PhotoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Photo entity
            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired();

                entity.Property(e => e.FilePath)
                    .IsRequired();

                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
