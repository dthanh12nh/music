using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.Dtos;
using Th.Music.IRepositories;
using Th.Music.IServices;
using Th.Music.Response;
using Th.Music.Validators;

namespace Th.Music.Services
{
    public class SongService : ISongService
    {
        readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public IResponse Add(SongDto dto)
        {
            var validator = new SongValidator(dto);
            if (validator.IsValid)
            {
                var entity = dto.ToEntity();
                var entityId = _songRepository.Add(entity);

                if (entityId > 0)
                {
                    return new ResponseModel
                    {
                        Succeed = true,
                        Message = "Create successfully"
                    };
                }
                else
                {
                    return new ResponseModel
                    {
                        Succeed = false,
                        Message = "System error"
                    };
                }
            }
            else
            {
                return new ResponseModel
                {
                    Succeed = false,
                    Errors = validator.Errors
                };
            }
        }
    }
}
