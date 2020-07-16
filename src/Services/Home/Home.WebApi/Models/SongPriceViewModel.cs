using System;
using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class SongPriceViewModel
    {
        public SongPriceViewModel()
        {
            Song = new HashSet<SongViewModel>();
        }

        public Guid UniqueId { get; set; }
        public decimal Price { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<SongViewModel> Song { get; set; }
    }
}
