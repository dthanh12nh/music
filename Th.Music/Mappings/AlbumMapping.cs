using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.Album;
using Th.Music.Models.Album;

namespace Th.Music.Mappings
{
    public static class AlbumMapping
    {
        public static CreateAlbumDto ToDto(this CreateAlbumModel model)
        {
            return new CreateAlbumDto
            {
                Name = model.Name,
                Avatar = model.Avatar,
                SingerId = model.SingerId
            };
        }
    }
}
