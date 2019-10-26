using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Music.DAL.Entities
{
    public class CommentEntity : StandardEntity
    {
        public string Content { get; set; }

        [ForeignKey("Song")]
        public Guid SongId { get; set; }

        public virtual SongEntity Song { get; set; }
        public virtual ICollection<ReplyCommentEntity> ReplyComments { get; set; }
    }
}
