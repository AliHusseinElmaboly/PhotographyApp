using PhotoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyApp.Services
{
    /// <summary>
    /// Interface for photo service operations.
    /// </summary>
    public interface IPhotoService
    {
        /// <summary>
        /// Retrieves all photos asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of photos.</returns>
        Task<IEnumerable<Photo>> GetPhotosAsync();

        /// <summary>
        /// Retrieves a photo by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the photo to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the photo.</returns>
        Task<Photo> GetPhotoAsync(int id);

        /// <summary>
        /// Adds a new photo asynchronously.
        /// </summary>
        /// <param name="photo">The photo to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddPhotoAsync(Photo photo);

        /// <summary>
        /// Updates an existing photo asynchronously.
        /// </summary>
        /// <param name="photo">The photo to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdatePhotoAsync(Photo photo);

        /// <summary>
        /// Deletes a photo by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the photo to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeletePhotoAsync(int id);
    }
}
