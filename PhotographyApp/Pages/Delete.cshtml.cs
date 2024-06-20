using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;
using System.Threading.Tasks;

namespace PhotographyApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IPhotoService _photoService;

        public DeleteModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [BindProperty(SupportsGet = true)]
        public int PhotoId { get; set; }

        public Photo Photo { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Photo = await _photoService.GetPhotoAsync(PhotoId);

            if (Photo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _photoService.DeletePhotoAsync(PhotoId);
            return RedirectToPage("./Index");
        }
    }
}
