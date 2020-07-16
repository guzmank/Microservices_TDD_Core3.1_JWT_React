using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("AlbumPrice", Schema = "dbo")]
    public partial class AlbumPriceEntity
    {
        public AlbumPriceEntity()
        {
            Album = new HashSet<AlbumEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<AlbumEntity> Album { get; set; }
    }
}
