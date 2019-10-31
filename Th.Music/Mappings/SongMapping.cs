using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.Song;
using Th.Music.Models;

namespace Th.Music.Mappings
{
    public static class SongMapping
    {
        public static CreateSongDto ToDto(this CreateSongModel model)
        {
            return new CreateSongDto
            {
                Title = model.Title,
                SingerId = model.SingerId,
                AlbumId = model.AlbumId,
                File = model.File,
                Avatar = model.Avatar
            };
        }
    }
}
