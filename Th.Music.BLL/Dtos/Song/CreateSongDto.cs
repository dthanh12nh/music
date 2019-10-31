using Microsoft.AspNetCore.Http;
using System;
using Th.Music.DAL.Entities;

namespace Th.Music.BLL.Dtos.Song
{
    public class CreateSongDto
    {
        public string Title { get; set; }
        public Guid? SingerId { get; set; }
        public Guid? AlbumId { get; set; }
        public IFormFile File { get; set; }
        public IFormFile Avatar { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
