using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Th.Music.BLL.Dtos.Song;
using Th.Music.DAL;

namespace Th.Music.BLL.Validators.Song
{
    public class CreateSongValidator : BaseValidator
    {
        public CreateSongValidator(CreateSongDto dto, MusicContext context)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                Errors.Add("Song Title must be filled in!");
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

            if (dto.AlbumId == null || dto.AlbumId == Guid.Empty)
            {
                Errors.Add("Please choose a album");
            }
            else
            {
                var album = context.Albums.FirstOrDefault(m => m.Id == dto.AlbumId);
                if (album == null)
                {
                    Errors.Add("Album does not existed!");
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

            if (dto.File == null)
            {
                Errors.Add("Please choose a music file!");
            }
            else
            {
                var imageExtension = Path.GetExtension(dto.File.FileName);
                if (imageExtension != ".mp3")
                {
                    Errors.Add("Extension of avatar image must be .mp3!");
                }
            }
        }
    }
}
