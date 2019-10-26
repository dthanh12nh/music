using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Th.Music.BLL.Dtos.Song;
using Th.Music.BLL.IServices;
using Th.Music.BLL.Mappings;
using Th.Music.BLL.Validators.Song;
using Th.Music.Core.Helpers;
using Th.Music.Core.Response;
using Th.Music.DAL.IRepositories;

namespace Th.Music.BLL.Services
{
    public class SongService : BaseService, ISongService
    {
        readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public Response<SongDto> Add(SongDto dto)
        {
            var validator = new SongValidator(dto);
            if (validator.IsValid)
            {
                var entity = dto.ToEntity();
                var entityId = _songRepository.Create(entity);
                dto.Id = entity.Id;

                if (entityId > 0)
                {
                    return Success<SongDto>("Create successfully");
                }
                else
                {
                    return Failure<SongDto>("System error");
                }
            }
            else
            {
                return Failure<SongDto>(validator.Errors);
            }
        }

        public List<SongDto> Search(SearchSongDto dto)
        {
            var returnedSongs = new List<SongDto>();
            var allSongs = _songRepository.GetAll();

            if (dto.Title != null)
            {
                //search with unicode characters
                var words = dto.Title.Trim().ToLower().Split(' ');
                foreach (var word in words)
                {
                    foreach (var song in allSongs)
                    {
                        var wordsOfTitle = song.Title.ToLower().Split(' ');
                        if (wordsOfTitle.Contains(word))
                        {
                            if (!returnedSongs.Any(p => p.Id == song.Id))
                            {
                                returnedSongs.Add(song.ToDto());
                            }
                        }
                    }
                }

                //search without unicode characters
                var nonUnicodeTitle = StringHelper.RemoveUnicode(dto.Title.Trim().ToLower());
                words = nonUnicodeTitle.Split(' ');
                foreach (var word in words)
                {
                    foreach (var song in allSongs)
                    {
                        var wordsOfTitle = StringHelper.RemoveUnicode(song.Title.ToLower()).Split(' ');
                        if (wordsOfTitle.Contains(word))
                        {
                            if (!returnedSongs.Any(p => p.Id == song.Id))
                            {
                                returnedSongs.Add(song.ToDto());
                            }
                        }
                    }
                }
            }

            return returnedSongs;
        }

        public SongDto GetById(Guid? id)
        {
            return _songRepository.GetById(id.Value).ToDto();
        }
    }
}
