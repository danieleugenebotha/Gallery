using Microsoft.EntityFrameworkCore;
using SimpleImagesGallery.Data.Models;
using System;

namespace SimpleImagesGallery.Data
{
    public class SimpleImageGalleryDbContext : DbContext
    {
        public SimpleImageGalleryDbContext(DbContextOptions options): base(options)
        {
                
        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
    }
}
