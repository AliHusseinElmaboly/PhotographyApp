using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PhotoApp.Data;
using PhotoApp.Models;
using PhotographyApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Tests.Services
{
    public class PhotoServiceTests
    {
        private SqlPhotoService _photoService;
        private PhotoDbContext _dbContext;
        private DbSet<Photo> _photoDbSet;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PhotoDbContext>()
                .UseInMemoryDatabase(databaseName: "PhotoAppTest")
                .Options;

            _dbContext = new PhotoDbContext(options);
            _photoDbSet = _dbContext.Set<Photo>();

            _photoService = new SqlPhotoService(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }

        [Test]
        public async Task GetPhotosAsync_ReturnsAllPhotos()
        {
            // Arrange
            _photoDbSet.AddRange(new List<Photo>
            {
                new Photo { Id = 8, Title = "Photo 1", Description = "Description 1", FilePath = "path/to/photo1.jpg" },
                new Photo { Id = 9, Title = "Photo 2", Description = "Description 2", FilePath = "path/to/photo2.jpg" }
            });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _photoService.GetPhotosAsync();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetPhotoAsync_ReturnsPhotoById()
        {
            // Arrange
            var photo = new Photo { Id = 10, Title = "Photo 1", Description = "Description 1", FilePath = "path/to/photo1.jpg" };
            _photoDbSet.Add(photo);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _photoService.GetPhotoAsync(10);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(photo.Id, result.Id);
        }

        [Test]
        public async Task AddPhotoAsync_AddsNewPhoto()
        {
            // Arrange
            var newPhoto = new Photo { Id = 1, Title = "New Photo", Description = "Description for new photo", FilePath = "path/to/newphoto.jpg" };

            // Act
            await _photoService.AddPhotoAsync(newPhoto);
            var addedPhoto = await _dbContext.Photos.FindAsync(1);

            // Assert
            Assert.IsNotNull(addedPhoto);
            Assert.AreEqual(newPhoto.Title, addedPhoto.Title);
        }

        [Test]
        public async Task DeletePhotoAsync_DeletesExistingPhoto()
        {
            // Arrange
            var photo = new Photo { Id = 5, Title = "Photo 1", Description = "Description 1", FilePath = "path/to/photo1.jpg" };
            _photoDbSet.Add(photo);
            await _dbContext.SaveChangesAsync();

            // Act
            await _photoService.DeletePhotoAsync(5);
            var deletedPhoto = await _dbContext.Photos.FindAsync(5);

            // Assert
            Assert.IsNull(deletedPhoto);
        }
    }
}
