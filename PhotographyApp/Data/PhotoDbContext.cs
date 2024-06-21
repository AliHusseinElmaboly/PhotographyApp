using Microsoft.EntityFrameworkCore;
using PhotoApp.Models;

namespace PhotoApp.Data
{
    /// <summary>
    /// Represents the database context for managing photos.
    /// </summary>
    public class PhotoDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the context.</param>
        public PhotoDbContext(DbContextOptions<PhotoDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of photos.
        /// </summary>
        public DbSet<Photo> Photos { get; set; }

        /// <summary>
        /// Configures the model that is to be used for the photos.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Photo entity
            modelBuilder.Entity<Photo>(entity =>
            {
                // Title is required
                entity.Property(e => e.Title)
                    .IsRequired();

                // FilePath is required
                entity.Property(e => e.FilePath)
                    .IsRequired();

                // UploadDate is of type datetime with default value set to current timestamp
                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
