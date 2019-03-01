using ARTBOX.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Services;
using SimpleImagesGallery.Data;
using System.Linq;

namespace ARTBOX.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var imageList = _imageService.GetImages();

            var model = new GalleryIndexViewModel()
            {
                Images = imageList,
                SearchQuery = ""
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var imageDetail = _imageService.GetById(id);

            var model = new ImageDetailViewModel()
            {
                ImageTitle = imageDetail.Title,
                ImageCreated = imageDetail.Created,
                ImageUrl = imageDetail.Url,
                ImageTags = imageDetail.Tags.Select(t => t.Description).ToList()
            };

            return View(model);
        }
    }
}