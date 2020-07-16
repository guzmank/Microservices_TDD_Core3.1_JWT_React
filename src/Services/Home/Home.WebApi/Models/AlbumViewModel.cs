using System;
using System.Collections.Generic;

namespace Home.WebApi.Models
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            AlbumRating = new HashSet<AlbumRatingViewModel>();
            Song = new HashSet<SongViewModel>();
        }

        public Guid UniqueId { get; set; }
        public Guid MusicTypeId { get; set; }
        public Guid ArtistId { get; set; }
        public Guid AlbumPriceId { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public DateTime? Released { get; set; }
        public string CopyRightInfo { get; set; }
        public string CoverPath { get; set; }
        public int TotalVotes { get; set; }
        public decimal TotalRating { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual AlbumPriceViewModel AlbumPrice { get; set; }
        public virtual ArtistViewModel Artist { get; set; }
        public virtual MusicTypeViewModel MusicType { get; set; }
        public virtual ICollection<AlbumRatingViewModel> AlbumRating { get; set; }
        public virtual ICollection<SongViewModel> Song { get; set; }
    }
}
