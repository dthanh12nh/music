using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.Singer;
using Th.Music.DAL.Entities;

namespace Th.Music.BLL.Mappings
{
    public static class SingerMapping
    {
        public static SingerEntity ToEntity(this CreateSingerDto dto)
        {
            return new SingerEntity
            {
                Name = dto.Name,
                CreatedUserId = dto.CreatedUserId
            };
        }

        public static ReturnedSingerDto ToReturnedDto(this SingerEntity entity)
        {
            return new ReturnedSingerDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
