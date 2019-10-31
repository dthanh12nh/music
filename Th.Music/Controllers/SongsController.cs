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
using Th.Music.Mappings;
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
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var song = _songService.GetById(id);

            if (song != null)
            {
                song.FileUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}/files/{song.Id}.mp3";
                song.AvatarUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}/images/songs/{song.Id}.jpg";
            }
            
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
                song.FileUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}/files/{song.Id}.mp3";
                song.AvatarUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}/images/songs/{song.Id}.jpg";
            }
            
            return Ok(songs);
        }

        [HttpPost]
        public IActionResult Create([FromForm]CreateSongModel model)
        {
            var dto = model.ToDto();
            dto.CreatedUserId = new Guid(User.Identity.Name);
            var result = _songService.Create(dto);

            if (result.Succeed)
            {
                var avatar = model.Avatar;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Songs", $"{result.Data.Id}{Path.GetExtension(avatar.FileName)}");
                using (var stream = System.IO.File.Create(path))
                {
                    avatar.CopyTo(stream);
                }

                var file = model.File;
                path = Path.Combine(Directory.GetCurrentDirectory(), "Files", $"{result.Data.Id}{Path.GetExtension(file.FileName)}");
                using (var stream = System.IO.File.Create(path))
                {
                    file.CopyTo(stream);
                }
            }

            return Ok(result);
        }
    }
}