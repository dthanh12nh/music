using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.BLL.Dtos.Singer;
using Th.Music.BLL.IServices;
using Th.Music.BLL.Mappings;
using Th.Music.BLL.Validators;
using Th.Music.Core.Response;
using Th.Music.DAL;
using Th.Music.DAL.IRepositories;

namespace Th.Music.BLL.Services
{
    public class SingerService : BaseService, ISingerService
    {
        readonly ISingerRepository _singerRepository;
        readonly MusicContext _context;
        public SingerService(
            MusicContext context,
            ISingerRepository singerRepository
            )
        {
            _context = context;
            _singerRepository = singerRepository;
        }

        public Response<ReturnedSingerDto> Create(CreateSingerDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();

            var validator = new CreateSingerValidator(dto, _context);
            if (validator.Failed)
            {
                transaction.Rollback();
                return Failure<ReturnedSingerDto>(validator.Errors);
            }

            var entity = dto.ToEntity();
            _singerRepository.Create(entity);

            _context.SaveChanges();
            transaction.Commit();

            var returnedDto = entity.ToReturnedDto();
            return Success("Create singer successfully!", returnedDto);
        }
    }
}
