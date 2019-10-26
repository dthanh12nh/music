using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Th.Music.BLL.IServices;
using Th.Music.Core;
using Th.Music.Mappings;
using Th.Music.Models.User;

namespace Th.Music.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly AppSettings _appSettings;
        readonly IUserService _userService;

        public UsersController(
            IOptions<AppSettings> appSettings,
            IUserService userService
            )
        {
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        [HttpPost, Route("register")]
        public IActionResult Regiser([FromBody]RegisterModel model)
        {
            try
            {
                var dto = model.ToDto();
                var response = _userService.Register(dto);
                return Ok(response);
            }
            catch
            {
                return BadRequest("System error!");
            }
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel model)
        {
            try
            {
                var dto = model.ToDto();
                var response = _userService.Login(dto);

                if (response.Succeed)
                {
                    var user = response.Data;
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Id.ToString())
                        }),
                        Expires = DateTime.Now.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    user.Token = tokenHandler.WriteToken(token);
                }

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest("System error!");
            }
        }
    }
}