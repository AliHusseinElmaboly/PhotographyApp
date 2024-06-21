using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyApp.Pages
{
    /// <summary>
    /// PageModel class for handling the index page operations.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly IPhotoService _photoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="photoService">The photo service instance.</param>
        public IndexModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Gets or sets the collection of photos to display.
        /// </summary>
        public IEnumerable<Photo> Photos { get; set; }

        /// <summary>
        /// Handles the HTTP GET request for the index page.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task OnGetAsync()
        {
            Photos = await _photoService.GetPhotosAsync();
        }

        /// <summary>
        /// Handles the HTTP POST request for deleting a photo.
        /// </summary>
        /// <param name="id">The ID of the photo to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _photoService.DeletePhotoAsync(id);
            return RedirectToPage();
        }
    }
}
