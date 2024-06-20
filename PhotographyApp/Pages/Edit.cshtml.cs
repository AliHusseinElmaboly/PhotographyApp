using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;
using System.Threading.Tasks;

namespace PhotographyApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly IPhotoService _photoService;

        public EditModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Photo Photo { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Photo = await _photoService.GetPhotoAsync(Id);

            if (Photo == null)
            {
                return NotFound();
            }

            return Page();
        }

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
