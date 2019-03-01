using SimpleImagesGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleImagesGallery.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetImages();
        IEnumerable<GalleryImage> GetWithTag(string tag);
        GalleryImage GetById(int id);
        Task SetImage(string title, string tags, string uri);
    }
}
