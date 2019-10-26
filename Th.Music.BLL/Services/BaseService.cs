using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Music.Core.Response;

namespace Th.Music.BLL.Services
{
    public abstract class BaseService
    {
        protected virtual Response<T> Success<T>(string message, T data = default)
        {
            return new Response<T>(message, new List<string>(), data);
        }

        protected virtual Response<T> Failure<T>(params string[] errors)
        {
            return new Response<T>(null, errors.ToList());
        }

        protected virtual Response<T> Failure<T>(IEnumerable<string> errors)
        {
            return new Response<T>(null, errors.ToList());
        }
    }
}
