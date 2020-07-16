using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.Framework.Data.Entities
{
    [Table("MusicType", Schema = "dbo")]
    public partial class MusicTypeEntity
    {
        public MusicTypeEntity()
        {
            Album = new HashSet<AlbumEntity>();
        }

        [Key]
        public Guid UniqueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlbumEntity> Album { get; set; }
    }
}
