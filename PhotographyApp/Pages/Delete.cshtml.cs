using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;
using System.Threading.Tasks;

namespace PhotographyApp.Pages
{
    /// <summary>
    /// PageModel class for handling photo deletion operations.
    /// </summary>
    public class DeleteModel : PageModel
    {
        private readonly IPhotoService _photoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteModel"/> class.
        /// </summary>
        /// <param name="photoService">The photo service instance.</param>
        public DeleteModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Gets or sets the ID of the photo to delete.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public int PhotoId { get; set; }

        /// <summary>
        /// Gets or sets the photo model to delete.
        /// </summary>
        public Photo Photo { get; set; }

        /// <summary>
        /// Handles the HTTP GET request for the delete confirmation page.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            Photo = await _photoService.GetPhotoAsync(PhotoId);

            if (Photo == null)
            {
                return NotFound();
            }

            return Page();
        }

        /// <summary>
        /// Handles the HTTP POST request for deleting a photo.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            await _photoService.DeletePhotoAsync(PhotoId);
            return RedirectToPage("./Index");
        }
    }
}
