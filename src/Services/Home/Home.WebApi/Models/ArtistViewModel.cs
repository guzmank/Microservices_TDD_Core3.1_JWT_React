using System;
using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class ArtistViewModel
    {
        public ArtistViewModel()
        {
            Album = new HashSet<AlbumViewModel>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<AlbumViewModel> Album { get; set; }
    }
}
