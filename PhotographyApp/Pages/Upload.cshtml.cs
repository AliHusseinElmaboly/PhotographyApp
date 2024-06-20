using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;
using System;
using System.IO;
using System.Threading.Tasks;

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
            public IFormFile PhotoFile { get; set; }
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
                FilePath = Input.PhotoFile.FileName
            };

            if (Input.PhotoFile != null && Input.PhotoFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(Input.PhotoFile.FileName)}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                photo.FilePath = $"/uploads/{fileName}";
            }

            await _photoService.AddPhotoAsync(photo);

            return RedirectToPage("./Index");
        }
    }
}
