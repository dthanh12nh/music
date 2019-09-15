using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.Dtos;
using Th.Music.Response;

namespace Th.Music.IServices
{
    public interface ISongService
    {
        IResponse Add(SongDto dto);
    }
}
