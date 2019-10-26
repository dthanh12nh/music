using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Music.DAL.Entities
{
    public class ReplyCommentEntity : StandardEntity
    {
        public string Content { get; set; }

        [ForeignKey("Comment")]
        public Guid CommentId { get; set; }

        public virtual CommentEntity Comment { get; set; }
    }
}
