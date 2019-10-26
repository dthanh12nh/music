using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.DAL.Entities
{
    public class SongEntity : StandardEntity
    {
        public string Title { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }
    }
}
