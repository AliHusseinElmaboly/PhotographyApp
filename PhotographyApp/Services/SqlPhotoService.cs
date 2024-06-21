using Microsoft.EntityFrameworkCore;
using PhotoApp.Models;
using PhotoApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyApp.Services
{
    /// <summary>
    /// Service class that handles operations related to photos using SQL-based storage.
    /// </summary>
    public class SqlPhotoService : IPhotoService
    {
        private readonly PhotoDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlPhotoService"/> class.
        /// </summary>
        /// <param name="context">The database context for photos.</param>
        public SqlPhotoService(PhotoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all photos asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of photos.</returns>
        public async Task<IEnumerable<Photo>> GetPhotosAsync()
        {
            return await _context.Photos.ToListAsync();
        }

        /// <summary>
        /// Retrieves a photo by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the photo to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the photo.</returns>
        public async Task<Photo> GetPhotoAsync(int id)
        {
            return await _context.Photos.FindAsync(id);
        }

        /// <summary>
        /// Adds a new photo asynchronously.
        /// </summary>
        /// <param name="photo">The photo to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddPhotoAsync(Photo photo)
        {
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing photo asynchronously.
        /// </summary>
        /// <param name="photo">The photo to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdatePhotoAsync(Photo photo)
        {
            _context.Entry(photo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a photo by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the photo to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeletePhotoAsync(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
