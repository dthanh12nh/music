using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.User;
using Th.Music.Models.User;

namespace Th.Music.Mappings
{
    public static class UserMapping
    {
        public static LoginDto ToDto(this LoginModel model)
        {
            return new LoginDto
            {
                UserName = model.UserName,
                Password = model.Password
            };
        }
    }
}
