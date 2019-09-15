using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.Entities;
using Th.Music.IRepositories;

namespace Th.Music.Repositories
{
    public class SongRepository : ISongRepository
    {
        readonly MusicContext _context;

        public SongRepository(MusicContext musicContext)
        {
            _context = musicContext;
        }

        public int Add(SongEntity entity)
        {
            _context.Songs.Add(entity);
            return _context.SaveChanges();
        }
    }
}
