using Microsoft.EntityFrameworkCore;
using Th.Music.DAL.Entities;

namespace Th.Music.DAL
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentEntity>()
                .HasOne(i => i.CreatedUser)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReplyCommentEntity>()
                .HasOne(i => i.CreatedUser)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlbumEntity>()
                .HasOne(i => i.CreatedUser)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<SongEntity> Songs { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<ReplyCommentEntity> ReplyComments { get; set; }
        public DbSet<SingerEntity> Singers { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
    }
}
