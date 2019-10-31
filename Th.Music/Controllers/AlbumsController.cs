using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Th.Music.BLL.IServices;
using Th.Music.Mappings;
using Th.Music.Models.Album;

namespace Th.Music.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        readonly IAlbumService _albumService;

        public AlbumsController(
            IAlbumService albumService
            )
        {
            _albumService = albumService;
        }

        [HttpPost]
        public IActionResult Create([FromForm]CreateAlbumModel model)
        {
            var dto = model.ToDto();
            dto.CreatedUserId = new Guid(User.Identity.Name);
            var response = _albumService.Create(dto);

            if (response.Succeed)
            {
                var avatar = model.Avatar;
                var album = response.Data;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Albums", $"{album.Id}{Path.GetExtension(avatar.FileName)}");
                using var stream = System.IO.File.Create(path);
                avatar.CopyTo(stream);
            }

            return Ok(response);
        }
    }
}