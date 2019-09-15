using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.Response
{
    public interface IResponse
    {
        bool Succeed { get; set; }
        string Message { get; set; }
        IResponseData Data { get; set; }
        List<string> Errors { get; set; }
    }
}
