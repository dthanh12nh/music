using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Th.Music.BLL.Dtos.User;
using Th.Music.BLL.IServices;
using Th.Music.BLL.Mappings;
using Th.Music.BLL.Validators.User;
using Th.Music.Core.Response;
using Th.Music.DAL;
using Th.Music.DAL.IRepositories;

namespace Th.Music.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        readonly MusicContext _context;
        readonly IUserRepository _userRepository;

        public UserService(MusicContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public UserDto GetById(Guid id)
        {
            return _userRepository.GetById(id).ToDto();
        }

        public Response<UserDto> Register(RegisterDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();

            var validator = new RegisterValidator(dto, _context);
            if (validator.Errors.Count > 0)
            {
                transaction.Rollback();
                return Failure<UserDto>(validator.Errors);
            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var entity = dto.ToEntity();
            entity.CreatedDate = DateTime.Now;
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            _userRepository.Create(entity);

            var returnedDto = dto.ToUserDto();
            returnedDto.Id = entity.Id;

            _context.SaveChanges();
            transaction.Commit();

            return Success("Register successfully!", returnedDto);
        }

        public Response<ReturnedLoginDto> Login(LoginDto dto)
        {
            var validator = new LoginValidator(dto);
            if (validator.Errors.Count > 0)
            {
                return Failure<ReturnedLoginDto>(validator.Errors);
            }

            if (Authenticate(dto, out ReturnedLoginDto user))
            {
                return Success("Login successfully!", user);
            }
            else
            {
                return Failure<ReturnedLoginDto>("User Name or Password is incorrect!");
            }
        }

        #region Private Methods

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        bool Authenticate(LoginDto dto, out ReturnedLoginDto userDto)
        {
            userDto = null;
            var userEntity = _context.Users.SingleOrDefault(x => x.UserName == dto.UserName);

            if (userEntity == null)
            {
                return false;
            }

            using (var hmac = new HMACSHA512(userEntity.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userEntity.PasswordHash[i]) 
                        return false;
                }
            }

            userDto = new ReturnedLoginDto
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                FullName = userEntity.FullName
            };

            return true;
        }

        #endregion 
    }
}
