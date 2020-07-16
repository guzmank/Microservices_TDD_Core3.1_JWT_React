using System;
using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class AlbumPriceViewModel
    {
        public AlbumPriceViewModel()
        {
            Album = new HashSet<AlbumViewModel>();
        }

        public Guid UniqueId { get; set; }
        public decimal Price { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<AlbumViewModel> Album { get; set; }
    }
}
