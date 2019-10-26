using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Th.Music.BLL.IServices;
using Th.Music.Constants;
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

        [HttpGet]
        public IActionResult Get(Guid? id)
        {
            if (id == null)
            {
                return BadRequest(Messages.ID_MUST_NOT_BE_EMPTY);
            }

            var song = _songService.GetById(id.Value);
            song.FileUrl = Path.Combine(Directory.GetCurrentDirectory(), "files", song.Id.ToString(), ".mp3");
            return Ok(song);
        }

        [HttpGet, Route("searching")]
        public IActionResult Search([FromQuery][Required]SongSearchModel model)
        {
            if (model == null)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var dto = model.ToDto();
            var songs = _songService.Search(dto);
            foreach (var song in songs)
            {
                song.FileUrl = Path.Combine(Directory.GetCurrentDirectory(), "files", $"{song.Id}.mp3");
            }
            
            return Ok(songs);
        }

        [HttpPost]
        public IActionResult Add([FromForm]SongModel model)
        {
            var dto = model.ToDto();
            var result = _songService.Add(dto);

            var file = model.File;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", $"{dto.Id}{Path.GetExtension(file.FileName)}");
            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }

            return Ok(result);
        }
    }
}