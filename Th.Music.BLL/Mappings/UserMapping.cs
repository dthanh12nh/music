using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.User;
using Th.Music.DAL.Entities;

namespace Th.Music.BLL.Mappings
{
    public static class UserMapping
    {
        public static UserEntity ToEntity(this RegisterDto dto)
        {
            return new UserEntity
            {
                UserName = dto.UserName,
                FullName = dto.FullName
            };
        }

        public static UserDto ToDto(this UserEntity entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                UserName = entity.UserName,
                FullName = entity.FullName
            };
        }

        public static UserDto ToUserDto(this RegisterDto dto)
        {
            return new UserDto
            {
                UserName = dto.UserName,
                FullName = dto.FullName
            };
        }

        public static UserDto ToUserDto(this LoginDto dto)
        {
            return new UserDto
            {
                UserName = dto.UserName
            };
        }
    }
}
