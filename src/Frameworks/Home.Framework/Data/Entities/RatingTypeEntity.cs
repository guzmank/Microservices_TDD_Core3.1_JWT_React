using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("RatingType", Schema = "dbo")]
    public partial class RatingTypeEntity
    {
        public RatingTypeEntity()
        {
            AlbumRating = new HashSet<AlbumRatingEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public virtual ICollection<AlbumRatingEntity> AlbumRating { get; set; }
    }
}
