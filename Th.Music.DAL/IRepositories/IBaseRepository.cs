using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Th.Music.DAL.Entities;

namespace Th.Music.DAL.IRepositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        int Create(TEntity entity);
        int Update(TEntity entity);
        int Delete(Guid id);
        int Delete(TEntity entity);
    }
}
