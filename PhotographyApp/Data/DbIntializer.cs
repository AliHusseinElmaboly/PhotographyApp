using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhotoApp.Models;
using System;
using System.Linq;

namespace PhotoApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PhotoDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PhotoDbContext>>()))
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Check if there are already photos in the database
                if (context.Photos.Any())
                {
                    return;   // Database has been seeded
                }

                var photos = new Photo[]
                {
                    new Photo
                    {
                        Title = "Sample Photo 1",
                        Description = "This is a sample photo.",
                        FilePath = "https://th.bing.com/th/id/OIP.yWIOQVgnGE3cVM4dtrW7EgHaHa?w=200&h=200&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                        UploadDate = DateTime.Now
                    },
                    new Photo
                    {
                        Title = "Sample Photo 2",
                        Description = "Another sample photo.",
                        FilePath = "https://th.bing.com/th/id/OIP.Hz3M3lyiuWM5nDaGvibPMQHaGM?w=238&h=199&c=7&r=0&o=5&dpr=1.3&pid=1.7", // Adjust as per your file structure
                        UploadDate = DateTime.Now
                    }
                    // Add more photos as needed
                };

                context.Photos.AddRange(photos);
                context.SaveChanges();
            }
        }
    }
}
