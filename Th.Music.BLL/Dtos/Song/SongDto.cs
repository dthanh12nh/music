using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.BLL.Dtos.Song
{
    public class SongDto : BaseDto
    {
        public string Title { get; set; }
        public Guid SingerId { get; set; }
        public Guid? AlbumId { get; set; }
        public string FileUrl { get; set; }
        public string AvatarUrl { get; set; }
        public SongSingerDto Singer { get; set; }
    }

    public class SongSingerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
