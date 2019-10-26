using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.BLL.Dtos.Singer
{
    public class ReturnedSingerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
    }
}
