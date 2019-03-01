using SimpleImagesGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARTBOX.Models
{
    public class ImageDetailViewModel
    {

        public int ImageId { get; set; }
        public string ImageTitle { get; set; }
        public DateTime ImageCreated { get; set; }
        public string ImageUrl { get; set; }
        public List<string> ImageTags { get; set; }

    }
}
