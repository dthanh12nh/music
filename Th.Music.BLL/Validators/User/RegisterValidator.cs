using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Music.BLL.Dtos.User;
using Th.Music.DAL;

namespace Th.Music.BLL.Validators.User
{
    public class RegisterValidator : BaseValidator
    {
        public RegisterValidator(RegisterDto dto, MusicContext context)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName))
            {
                Errors.Add("User Name must be filled in!");
            }
            else
            {
                if (dto.UserName.Contains(' '))
                {
                    Errors.Add("User Name does not contain whitespace");
                }
                else
                {
                    var user = context.Users.FirstOrDefault(m => m.UserName == dto.UserName);
                    if (user != null)
                    {
                        Errors.Add("User Name existed!");
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(dto.FullName))
            {
                Errors.Add("Full Name must be filled in!");
            }

            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                Errors.Add("Password must be filled in!");
            }

            if (string.IsNullOrWhiteSpace(dto.ConfirmPassword))
            {
                Errors.Add("Confirm Password must be filled in!");
            }

            if(!string.IsNullOrWhiteSpace(dto.Password) && !string.IsNullOrWhiteSpace(dto.ConfirmPassword))
            {
                if (dto.Password != dto.ConfirmPassword)
                {
                    Errors.Add("Password and Confirm Password must match!");
                }
            }
        }
    }
}
