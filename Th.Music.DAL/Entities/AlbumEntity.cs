using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Music.DAL.Entities
{
    public class AlbumEntity : StandardEntity
    {
        public string Name { get; set; }

        [ForeignKey("Singer")]
        public Guid SingerId { get; set; }

        public virtual SingerEntity Singer { get; set; }
    }
}
