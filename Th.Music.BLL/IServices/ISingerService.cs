using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.Singer;
using Th.Music.Core.Response;

namespace Th.Music.BLL.IServices
{
    public interface ISingerService
    {
        Response<ReturnedSingerDto> Create(CreateSingerDto dto);
    }
}
