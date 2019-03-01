using SimpleImagesGallery.Data.Models;
using System.Collections.Generic;

namespace ARTBOX.Models
{
    public class GalleryIndexViewModel
    {
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }

    }
}
