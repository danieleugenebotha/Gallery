using Microsoft.EntityFrameworkCore;
using SimpleImagesGallery.Data;
using SimpleImagesGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task SetImage(string title, string tags, string uri)
        {
            var image = new GalleryImage()
            {
                Title = title,
                Tags = ParseTags(tags),
                Url = uri,
                Created = DateTime.Now
            };

            _context.Add(image);
            await _context.SaveChangesAsync();
        }

        private List<ImageTag> ParseTags(string tags)
        {
            var tagList = tags.Split(",").ToList();

            var imagesTags = new List<ImageTag>();

            foreach (var tag in tagList)
            {
                imagesTags.Add(new ImageTag()
                {
                    Description = tag,
                });
            }

            return imagesTags;
        }
    }
}
