using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;

namespace PhotographyApp.Pages
{
    public class UploadModel : PageModel
    {
        private readonly IPhotoService _photoService;

        public UploadModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string PhotoUrl { get; set; }
        }

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
