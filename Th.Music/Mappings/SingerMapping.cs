using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.Singer;
using Th.Music.Models.Singer;

namespace Th.Music.Mappings
{
    public static class SingerMapping
    {
        public static CreateSingerDto ToDto(this CreateSingerModel model)
        {
            return new CreateSingerDto
            {
                Name = model.Name,
                Avatar = model.Avatar
            };
        }
    }
}
