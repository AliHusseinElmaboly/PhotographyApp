using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;
using System;
using System.Threading.Tasks;

namespace PhotographyApp.Pages
{
    /// <summary>
    /// PageModel class for handling photo editing operations.
    /// </summary>
    public class EditModel : PageModel
    {
        private readonly IPhotoService _photoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditModel"/> class.
        /// </summary>
        /// <param name="photoService">The photo service instance.</param>
        public EditModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Gets or sets the ID of the photo to edit.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the photo model to edit.
        /// </summary>
        [BindProperty]
        public Photo Photo { get; set; }

        /// <summary>
        /// Handles the HTTP GET request for the edit page.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            Photo = await _photoService.GetPhotoAsync(Id);

            if (Photo == null)
            {
                return NotFound();
            }

            return Page();
        }

        /// <summary>
        /// Handles the HTTP POST request for updating a photo.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Photo.UploadDate = DateTime.Now;
            await _photoService.UpdatePhotoAsync(Photo);

            return RedirectToPage("./Index");
        }
    }
}
