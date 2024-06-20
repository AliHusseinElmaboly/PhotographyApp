using Microsoft.EntityFrameworkCore;
using PhotoApp.Models;
using PhotoApp.Data;
using PhotoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyApp.Services
{
    public class SqlPhotoService : IPhotoService
    {
        private readonly PhotoDbContext _context;

        public SqlPhotoService(PhotoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotosAsync()
        {
            return await _context.Photos.ToListAsync();
        }

        public async Task<Photo> GetPhotoAsync(int id)
        {
            return await _context.Photos.FindAsync(id);
        }

        public async Task AddPhotoAsync(Photo photo)
        {
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhotoAsync(Photo photo)
        {
            _context.Entry(photo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

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
