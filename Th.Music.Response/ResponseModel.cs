using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.Response
{
    public class ResponseModel : IResponse
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public IResponseData Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
