using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("AlbumRating", Schema = "dbo")]
    public partial class AlbumRatingEntity
    {
        [Key]
        public Guid UniqueId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid RatingTypeId { get; set; }

        public virtual AlbumEntity Album { get; set; }
        public virtual RatingTypeEntity RatingType { get; set; }
    }
}
