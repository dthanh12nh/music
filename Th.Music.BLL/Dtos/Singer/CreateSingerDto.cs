using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Music.BLL.Dtos.Singer
{
    public class CreateSingerDto
    {
        public string Name { get; set; }
        public IFormFile Avatar { get; set; }
        public Guid CreatedUserId { get; set; }
    }
}
