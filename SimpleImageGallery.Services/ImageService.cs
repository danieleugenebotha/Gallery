using Microsoft.EntityFrameworkCore;
using SimpleImagesGallery.Data;
using SimpleImagesGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly SimpleImageGalleryDbContext _context;

        public ImageService(SimpleImageGalleryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GalleryImage> GetImages()
        {
            return _context.GalleryImages.Include(img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetImages().FirstOrDefault(image => image.Id == id);
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetImages()
                .Where(img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
