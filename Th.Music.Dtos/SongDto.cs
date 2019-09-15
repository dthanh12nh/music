using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.Entities;

namespace Th.Music.Dtos
{
    public class SongDto : BaseDto
    {
        public string Name { get; set; }

        public SongEntity ToEntity()
        {
            return new SongEntity
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
