using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Th.Music.Models.Singer
{
    public class CreateSingerModel
    {
        public string Name { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
