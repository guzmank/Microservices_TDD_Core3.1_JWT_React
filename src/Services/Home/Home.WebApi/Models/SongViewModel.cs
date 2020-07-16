using System;

namespace Home.WebApi.Models
{
    public class SongViewModel
    {
        public Guid UniqueId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid SongPriceId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public int? Popularity { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual AlbumViewModel Album { get; set; }
        public virtual SongPriceViewModel SongPrice { get; set; }
    }
}
