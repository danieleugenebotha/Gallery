using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARTBOX.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using SimpleImagesGallery.Data;

namespace ARTBOX.Controllers
{
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment _he;
        private readonly IImage _imageService;

        public ImageController(IHostingEnvironment he, IImage imageService)
        {
            _he = he;
            _imageService = imageService;
        }

        public IActionResult Upload()
        {
            var model = new UploadImageModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewImage(string title, string tags, IFormFile file)
        {
            if (file != null && title != string.Empty && tags != string.Empty)
            {
                var filename = Path.Combine(_he.WebRootPath, "images", Path.GetFileName(file.FileName));
                await file.CopyToAsync(new FileStream(filename, FileMode.Create));

                string shortFileName = Path.Combine("/images", Path.GetFileName(file.FileName));

                 var newShortFileName = shortFileName.Replace('\\','/');

                await _imageService.SetImage(title, tags, newShortFileName);

                return RedirectToAction("Index", "Gallery");

            }
            else
            {
                return RedirectToAction("Index","Gallery");
            }

        }
    }
}