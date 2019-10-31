using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Music.DAL.Entities
{
    public class SongEntity : StandardEntity
    {
        public string Title { get; set; }
        public string NonUnicodeTitle { get; set; }

        [ForeignKey("Album")]
        public Guid? AlbumId { get; set; }

        public virtual AlbumEntity Album { get; set; }
        public virtual ICollection<CommentEntity> Comments { get; set; }
    }
}
