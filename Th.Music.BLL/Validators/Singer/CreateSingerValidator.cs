using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Th.Music.BLL.Dtos.Singer;
using Th.Music.DAL;

namespace Th.Music.BLL.Validators.Singer
{
    public class CreateSingerValidator : BaseValidator
    {
        public CreateSingerValidator(CreateSingerDto dto, MusicContext context)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                Errors.Add("Singer Name must be filled in!");
            }
            else
            {
                var singer = context.Singers.FirstOrDefault(m => m.Name.ToLower() == dto.Name.Trim().ToLower());
                if (singer != null)
                {
                    Errors.Add("Album Name existed!");
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
