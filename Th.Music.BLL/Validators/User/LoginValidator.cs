using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.User;
using Th.Music.DAL;

namespace Th.Music.BLL.Validators.User
{
    public class LoginValidator : BaseValidator
    {
        public LoginValidator(LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName))
            {
                Errors.Add("User Name must be filled in!");
            }

            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                Errors.Add("Password must be filled in!");
            }
        }
    }
}
