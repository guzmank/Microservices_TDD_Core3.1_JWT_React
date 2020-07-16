using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Song", Schema = "dbo")]
    public partial class SongEntity
    {
        [Key]
        public Guid UniqueId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid SongPriceId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public int? Popularity { get; set; }

        public virtual AlbumEntity Album { get; set; }
        public virtual SongPriceEntity SongPrice { get; set; }
    }
}
