using Th.Music.Entities;

namespace Th.Music.IRepositories
{
    public interface ISongRepository
    {
        int Add(SongEntity entity);
    }
}
