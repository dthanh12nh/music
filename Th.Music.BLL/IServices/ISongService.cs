using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.Song;
using Th.Music.Core.Response;

namespace Th.Music.BLL.IServices
{
    public interface ISongService
    {
        Response<SongDto> Add(SongDto dto);
        List<SongDto> Search(SearchSongDto dto);
        SongDto GetById(Guid? id);
    }
}
