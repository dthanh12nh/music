using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.DAL.Entities;

namespace Th.Music.BLL.Dtos.User
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
