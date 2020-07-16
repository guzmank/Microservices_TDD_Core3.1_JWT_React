using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("SongPrice", Schema = "dbo")]
    public partial class SongPriceEntity
    {
        public SongPriceEntity()
        {
            Song = new HashSet<SongEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<SongEntity> Song { get; set; }
    }
}
