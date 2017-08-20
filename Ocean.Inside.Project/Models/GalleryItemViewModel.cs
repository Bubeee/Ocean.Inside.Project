using System.Collections.Generic;

namespace Ocean.Inside.Project.Models
{
    using System.Linq;

    public class GalleryItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ImageViewModel MainImage => this.Images?.FirstOrDefault() ?? new ImageViewModel();

        public IList<ImageViewModel> Images { get; set; }
    }
}