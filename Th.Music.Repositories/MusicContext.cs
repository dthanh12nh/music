using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Th.Music.Entities;

namespace Th.Music.Repositories
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        { }

        public DbSet<SongEntity> Songs { get; set; }
    }
}
