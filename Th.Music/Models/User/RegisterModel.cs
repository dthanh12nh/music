using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Music.BLL.Dtos.User;

namespace Th.Music.Models.User
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterDto ToDto()
        {
            return new RegisterDto
            {
                UserName = UserName,
                FullName = FullName,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };
        }
    }
}
