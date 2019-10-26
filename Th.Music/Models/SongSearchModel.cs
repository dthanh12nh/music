using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.Song;

namespace Th.Music.Models
{
    public class SongSearchModel
    {
        public string Title { get; set; }

        public SearchSongDto ToDto()
        {
            return new SearchSongDto
            {
                Title = Title
            };
        }
    }
}
