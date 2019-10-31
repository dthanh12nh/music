using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Th.Music.BLL.Dtos.Song;
using Th.Music.BLL.IServices;
using Th.Music.BLL.Mappings;
using Th.Music.BLL.Validators.Song;
using Th.Music.Core.Helpers;
using Th.Music.Core.Response;
using Th.Music.DAL;
using Th.Music.DAL.IRepositories;

namespace Th.Music.BLL.Services
{
    public class SongService : BaseService, ISongService
    {
        readonly MusicContext _context;
        readonly ISongRepository _songRepository;

        public SongService(
            MusicContext context,
            ISongRepository songRepository
            )
        {
            _context = context;
            _songRepository = songRepository;
        }

        public SongDto GetById(Guid id)
        {
            return _songRepository
                .DbSet
                .Include(m => m.Album)
                .Include("Album.Singer")
                .FirstOrDefault(m => m.Id == id)
                ?.ToDto();
        }

        public Response<SongDto> Create(CreateSongDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();

            var validator = new CreateSongValidator(dto, _context);
            if (validator.Failed)
            {
                transaction.Rollback();
                return Failure<SongDto>(validator.Errors);
            }

            var entity = dto.ToEntity();
            entity.NonUnicodeTitle = StringHelper.RemoveUnicode(entity.Title);
            _songRepository.Create(entity);

            transaction.Commit();
            _context.SaveChanges();

            var returnedDto = entity.ToDto();
            return Success("Create song successfully!", returnedDto);
        }

        public List<SongDto> Search(SearchSongDto dto)
        {
            var returnedSongs = new List<SongDto>();
            var AllSongs = _songRepository.GetAll()
                .Include(m => m.Album)
                .Include("Album.Singer");

            if (dto.Title != null)
            {
                //search with unicode characters
                var unicodeSongs = AllSongs.Where(m => m.Title.ToLower().Contains(dto.Title.ToLower().Trim()));

                //search without unicode characters
                var nonUnicodeTitle = StringHelper.RemoveUnicode(dto.Title.Trim().ToLower());
                var nonUnicodeSongs = AllSongs.Where(m => m.NonUnicodeTitle.ToLower().Contains(nonUnicodeTitle));

                returnedSongs = unicodeSongs
                    .Union(nonUnicodeSongs)
                    .Distinct()
                    .ToDtos()
                    .ToList();
            }

            return returnedSongs;
        }
    }
}
