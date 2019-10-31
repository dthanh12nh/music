using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Th.Music.Models.Album
{
    public class CreateAlbumModel
    {
        public string Name { get; set; }
        public IFormFile Avatar { get; set; }
        public Guid? SingerId { get; set; }
    }
}
