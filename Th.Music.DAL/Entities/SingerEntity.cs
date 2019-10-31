using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.DAL.Entities
{
    public class SingerEntity : StandardEntity
    {
        public string Name { get; set; }

        public virtual ICollection<AlbumEntity> Albums { get; set; }
    }
}
