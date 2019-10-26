using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.Song;

namespace Th.Music.Models
{
    public class SongModel
    {
        public string Title { get; set; }
        public IFormFile File { get; set; }

        public SongDto ToDto()
        {
            return new SongDto
            {
                Title = Title
            };
        }
    }
}
