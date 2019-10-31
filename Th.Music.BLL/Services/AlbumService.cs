using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Music.BLL.Dtos.Album;
using Th.Music.BLL.IServices;
using Th.Music.BLL.Mappings;
using Th.Music.BLL.Validators.Album;
using Th.Music.Core.Response;
using Th.Music.DAL;
using Th.Music.DAL.IRepositories;

namespace Th.Music.BLL.Services
{
    public class AlbumService : BaseService, IAlbumService
    {
        readonly IAlbumRepository _albumRepository;
        readonly MusicContext _context;
        public AlbumService(
            MusicContext context,
            IAlbumRepository albumRepository
            )
        {
            _context = context;
            _albumRepository = albumRepository;
        }

        public List<AlbumDto> GetAll()
        {
            return
                _albumRepository
                .GetAll()
                .Select(m => m.ToDto())
                .ToList();
        }

        public Response<AlbumDto> Create(CreateAlbumDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();

            var validator = new CreateAlbumValidator(dto, _context);
            if (validator.Failed)
            {
                transaction.Rollback();
                return Failure<AlbumDto>(validator.Errors);
            }

            var entity = dto.ToEntity();
            _albumRepository.Create(entity);

            _context.SaveChanges();
            transaction.Commit();

            var returnedDto = entity.ToDto();
            return Success("Create album successfully!", returnedDto);
        }
    }
}
