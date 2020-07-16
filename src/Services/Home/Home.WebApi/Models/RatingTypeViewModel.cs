using System;
using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class RatingTypeViewModel
    {
        public RatingTypeViewModel()
        {
            AlbumRating = new HashSet<AlbumRatingViewModel>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<AlbumRatingViewModel> AlbumRating { get; set; }
    }
}
