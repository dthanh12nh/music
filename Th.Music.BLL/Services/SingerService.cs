using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Th.Music.BLL.Dtos.Album;
using Th.Music.BLL.Dtos.Singer;
using Th.Music.BLL.IServices;
using Th.Music.BLL.Mappings;
using Th.Music.BLL.Validators.Singer;
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

        public List<ReturnedSingerDto> GetAll()
        {
            return 
                _singerRepository
                .GetAll()
                .Select(m => m.ToReturnedDto())
                .ToList();
        }

        public List<AlbumDto> GetAlbumsBySingerId(Guid singerId)
        {
            return
                _singerRepository
                .GetAll()
                .Include(m => m.Albums)
                .First(m => m.Id == singerId)
                .Albums
                .Select(m => m.ToDto())
                .ToList();
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
