using System;

namespace Home.WebApi.Models
{
    public class AlbumRatingViewModel
    {
        public Guid UniqueId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid RatingTypeId { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual AlbumViewModel Album { get; set; }
        public virtual RatingTypeViewModel RatingType { get; set; }
    }
}
