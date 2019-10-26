using System;
using Th.Music.DAL.Entities;

namespace Th.Music.BLL.Dtos.Song
{
    public class SongDto : BaseDto
    {
        public string Title { get; set; }
        public string FileUrl { get; set; }

        public SongEntity ToEntity()
        {
            return new SongEntity
            {
                Id = Id,
                Title = Title,
                CreatedDate = DateTime.Now,
                CreatedUserId = Id
            };
        }
    }
}
