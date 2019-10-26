using System.Collections.Generic;
using Th.Music.BLL.Dtos.Song;
using Th.Music.DAL.Entities;

namespace Th.Music.BLL.Mappings
{
    public static class SongMapping
    {
        public static SongDto ToDto(this SongEntity entity)
        {
            return new SongDto
            {
                Id = entity.Id,
                Title = entity.Title
            };
        }

        public static IEnumerable<SongDto> ToDtos(this IEnumerable<SongEntity> entities)
        {
            foreach (var entity in entities)
            {
                yield return ToDto(entity);
            }
        }
    }
}
