using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.BLL.Dtos.User
{
    public class ReturnedLoginDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
    }
}
