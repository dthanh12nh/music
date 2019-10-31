using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.Album;
using Th.Music.DAL.Entities;

namespace Th.Music.BLL.Mappings
{
    public static class AlbumMapping
    {
        public static AlbumEntity ToEntity(this CreateAlbumDto dto)
        {
            return new AlbumEntity
            {
                Name = dto.Name,
                SingerId = dto.SingerId.Value,
                CreatedUserId = dto.CreatedUserId
            };
        }

        public static AlbumDto ToDto(this AlbumEntity entity)
        {
            return new AlbumDto
            {
                Id = entity.Id,
                Name = entity.Name,
                SingerId = entity.SingerId
            };
        }
    }
}
