using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("Artist", Schema = "dbo")]
    public partial class ArtistEntity
    {
        public ArtistEntity()
        {
            Album = new HashSet<AlbumEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlbumEntity> Album { get; set; }
    }
}
