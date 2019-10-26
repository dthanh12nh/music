using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Music.DAL.Entities
{
    public abstract class StandardEntity : BaseEntity
    {
        [ForeignKey("CreatedUser")]
        public Guid CreatedUserId { get; set; }
        public virtual UserEntity CreatedUser { get; set; }
    }
}
