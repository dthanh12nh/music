using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.DAL.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
