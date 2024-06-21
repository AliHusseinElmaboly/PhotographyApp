using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;
using System;
using System.Threading.Tasks;

namespace PhotographyApp.Pages
{
    /// <summary>
    /// PageModel class for handling photo upload operations.
    /// </summary>
    public class UploadModel : PageModel
    {
        private readonly IPhotoService _photoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadModel"/> class.
        /// </summary>
        /// <param name="photoService">The photo service instance.</param>
        public UploadModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Gets or sets the input model for photo upload.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// Represents the input model for photo upload.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Gets or sets the title of the photo.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the description of the photo.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets the URL of the photo.
            /// </summary>
            public string PhotoUrl { get; set; }
        }

        /// <summary>
        /// Handles the HTTP POST request for uploading a photo.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var photo = new Photo
            {
                Title = Input.Title,
                Description = Input.Description,
                UploadDate = DateTime.UtcNow,
                FilePath = Input.PhotoUrl
            };

            await _photoService.AddPhotoAsync(photo);

            return RedirectToPage("./Index");
        }
    }
}
