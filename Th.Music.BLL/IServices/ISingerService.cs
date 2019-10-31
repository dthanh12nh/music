using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.Album;
using Th.Music.BLL.Dtos.Singer;
using Th.Music.Core.Response;

namespace Th.Music.BLL.IServices
{
    public interface ISingerService
    {
        List<ReturnedSingerDto> GetAll();
        List<AlbumDto> GetAlbumsBySingerId(Guid singerId);
        Response<ReturnedSingerDto> Create(CreateSingerDto dto);
    }
}
