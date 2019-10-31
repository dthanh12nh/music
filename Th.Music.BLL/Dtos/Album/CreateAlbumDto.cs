using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.BLL.Dtos.Album
{
    public class CreateAlbumDto
    {
        public string Name { get; set; }
        public IFormFile Avatar { get; set; }
        public Guid? SingerId { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
