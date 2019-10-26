using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.User;
using Th.Music.Core.Response;

namespace Th.Music.BLL.IServices
{
    public interface IUserService
    {
        Response<UserDto> Register(RegisterDto user);
        Response<ReturnedLoginDto> Login(LoginDto user);
        UserDto GetById(Guid id);
    }
}
