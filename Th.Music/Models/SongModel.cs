using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.Dtos;

namespace Th.Music.Models
{
    public class SongModel
    {
        public string Name { get; set; }

        public SongDto ToDto()
        {
            return new SongDto
            {
                Name = Name
            };
        }
    }
}
