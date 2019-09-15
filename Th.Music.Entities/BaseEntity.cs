using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
