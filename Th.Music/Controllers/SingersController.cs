using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Th.Music.BLL.IServices;
using Th.Music.Mappings;
using Th.Music.Models.Singer;

namespace Th.Music.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SingersController : ControllerBase
    {
        readonly ISingerService _singerService;

        public SingersController(
            ISingerService singerService
            )
        {
            _singerService = singerService;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult GetAll()
        {
            var response = _singerService.GetAll();
            return Ok(response);
        }

        [HttpGet, AllowAnonymous, Route("{singerId}/albums")]
        public IActionResult GetAlbumsBySingerId(Guid singerId)
        {
            var response = _singerService.GetAlbumsBySingerId(singerId);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromForm]CreateSingerModel model)
        {
            var dto = model.ToDto();
            dto.CreatedUserId = new Guid(User.Identity.Name);
            var response =_singerService.Create(dto);

            if (response.Succeed)
            {
                var avatar = model.Avatar;
                var singer = response.Data;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Singers", $"{singer.Id}{Path.GetExtension(avatar.FileName)}");
                using var stream = System.IO.File.Create(path);
                avatar.CopyTo(stream);
            }

            return Ok(response);
        }
    }
}