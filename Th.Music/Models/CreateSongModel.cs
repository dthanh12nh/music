using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.Song;

namespace Th.Music.Models
{
    public class CreateSongModel
    {
        public string Title { get; set; }
        public Guid? SingerId { get; set; }
        public Guid? AlbumId { get; set; }
        public IFormFile File { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
