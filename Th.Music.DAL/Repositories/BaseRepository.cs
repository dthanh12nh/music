using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Music.DAL.Entities;
using Th.Music.DAL.IRepositories;

namespace Th.Music.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity: BaseEntity
    {
        protected readonly MusicContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(MusicContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public int Create(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _dbSet.Add(entity);
            return SaveChanges();
        }

        public int Delete(Guid id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }

        public int Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(m => m.Id == id);
        }

        public int Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return SaveChanges();        
        }

        #region Private Methods

        int SaveChanges()
        {
            if (_context.Database.CurrentTransaction == null)
            {
                return _context.SaveChanges();
            }

            return 0;
        }

        #endregion
    }
}
