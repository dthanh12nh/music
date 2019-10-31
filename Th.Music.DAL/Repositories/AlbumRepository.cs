using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.DAL.Entities;
using Th.Music.DAL.IRepositories;

namespace Th.Music.DAL.Repositories
{
    public class AlbumRepository : BaseRepository<AlbumEntity>, IAlbumRepository
    {
        public AlbumRepository(MusicContext context) : base(context)
        { }
    }
}
