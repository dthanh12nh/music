using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Th.Music.IServices;
using Th.Music.Models;

namespace Th.Music.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpPost]
        public IActionResult Add(SongModel model)
        {
            var dto = model.ToDto();
            var result = _songService.Add(dto);
            return Ok(result);
        }
    }
}