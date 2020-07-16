using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Album", Schema = "dbo")]
    public partial class AlbumEntity
    {
        public AlbumEntity()
        {
            AlbumRating = new HashSet<AlbumRatingEntity>();
            Song = new HashSet<SongEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public Guid MusicTypeId { get; set; }
        public Guid ArtistId { get; set; }
        public Guid AlbumPriceId { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public DateTime? Released { get; set; }
        public string CopyRightInfo { get; set; }
        public string CoverPath { get; set; }

        public virtual AlbumPriceEntity AlbumPrice { get; set; }
        public virtual ArtistEntity Artist { get; set; }
        public virtual MusicTypeEntity MusicType { get; set; }
        public virtual ICollection<AlbumRatingEntity> AlbumRating { get; set; }
        public virtual ICollection<SongEntity> Song { get; set; }
    }

}
