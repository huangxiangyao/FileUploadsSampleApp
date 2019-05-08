using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace SampleApp.Pages
{
    public class DeletePhysicalFileModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IFileProvider _fileProvider;

        public DeletePhysicalFileModel(IConfiguration config, IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
            _config = config;
        }

        public IFileInfo RemoveFile { get; private set; }

        public IActionResult OnGet(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return RedirectToPage("/Index");
            }

            RemoveFile = _fileProvider.GetFileInfo(fileName);

            if (!RemoveFile.Exists)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPost(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return RedirectToPage("/Index");
            }

            RemoveFile = _fileProvider.GetFileInfo(fileName);

            if (RemoveFile.Exists)
            {
                System.IO.File.Delete(RemoveFile.PhysicalPath);
            }

            return RedirectToPage("./Index");
        }
    }
}
