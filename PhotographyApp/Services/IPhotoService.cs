using PhotoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyApp.Services
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetPhotosAsync();
        Task<Photo> GetPhotoAsync(int id);
        Task AddPhotoAsync(Photo photo);
        Task UpdatePhotoAsync(Photo photo);
        Task DeletePhotoAsync(int id);
    }
}
