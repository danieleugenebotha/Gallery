using SimpleImagesGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleImagesGallery.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetImages();
        IEnumerable<GalleryImage> GetWithTag(string tag);
        GalleryImage GetById(int id);
    }
}
