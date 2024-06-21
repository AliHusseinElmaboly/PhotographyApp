using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoApp.Models;
using PhotographyApp.Services;

namespace PhotographyApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPhotoService _photoService;

        public IndexModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public IEnumerable<Photo> Photos { get; set; }

        public async Task OnGetAsync()
        {
            Photos = await _photoService.GetPhotosAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _photoService.DeletePhotoAsync(id);
            return RedirectToPage();
        }
    }
}
