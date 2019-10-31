using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.Album;
using Th.Music.Core.Response;

namespace Th.Music.BLL.IServices
{
    public interface IAlbumService
    {
        List<AlbumDto> GetAll();
        Response<AlbumDto> Create(CreateAlbumDto dto);
    }
}
