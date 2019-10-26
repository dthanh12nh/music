using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.User;

namespace Th.Music.Models.User
{
    public class UserModel
    {
        public UserDto ToDto()
        {
            return new UserDto();
        }
    }
}
