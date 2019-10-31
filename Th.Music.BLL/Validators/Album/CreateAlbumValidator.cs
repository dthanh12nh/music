using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Th.Music.BLL.Dtos.Album;
using Th.Music.DAL;

namespace Th.Music.BLL.Validators.Album
{
    public class CreateAlbumValidator : BaseValidator
    {
        public CreateAlbumValidator(CreateAlbumDto dto, MusicContext context)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                Errors.Add("Album Name must be filled in!");
            }
            else
            {
                var album = context.Albums.FirstOrDefault(m => m.Name.ToLower() == dto.Name.Trim().ToLower());
                if (album != null)
                {
                    Errors.Add("Album Name existed!");
                }
            }

            if (dto.SingerId == null || dto.SingerId == Guid.Empty)
            {
                Errors.Add("Please choose a singer");
            }
            else
            {
                var singer = context.Singers.FirstOrDefault(m => m.Id == dto.SingerId);
                if (singer == null)
                {
                    Errors.Add("Singer does not existed!");
                }
            }

            if (dto.Avatar == null)
            {
                Errors.Add("Please choose a avatar!");
            }
            else
            {
                var imageExtension = Path.GetExtension(dto.Avatar.FileName);
                if (imageExtension != ".jpg")
                {
                    Errors.Add("Extension of avatar image must be .jpg!");
                }
            }
        }
    }
}
