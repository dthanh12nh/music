using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.BLL.Dtos.Album
{
    public class AlbumDto : BaseDto
    {
        public string Name { get; set; }
        public Guid SingerId { get; set; }
    }
}
