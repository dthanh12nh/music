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

        public DbSet<TEntity> DbSet { get => _dbSet; }

        public virtual int Create(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _dbSet.Add(entity);
            return SaveChanges();
        }

        public virtual int Delete(Guid id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }

        public virtual int Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return SaveChanges();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(m => m.Id == id);
        }

        public virtual int Update(TEntity entity)
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
