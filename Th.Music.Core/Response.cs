using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.Core.Response
{
    public class Response<T>
    {
        public bool Succeed { get => Errors.Count == 0; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public Response(string message, List<string> errors, T data = default)
        {
            Message = message;
            Data = data;
            Errors = errors ?? new List<string>();
        }
    }
}
