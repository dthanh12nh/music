using System;
using System.Collections.Generic;
using System.Linq;
using Th.Music.DAL.Entities;
using Th.Music.DAL.IRepositories;

namespace Th.Music.DAL.Repositories
{
    public class SongRepository : BaseRepository<SongEntity>, ISongRepository
    {
        public SongRepository(MusicContext context) : base(context)
        { }
    }
}
