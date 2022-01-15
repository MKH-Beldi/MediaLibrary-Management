using System;
using Data.Infrastructure;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utwk = new UnitOfWork(factory);
        public virtual void Add(TEntity entity)
        {
            utwk.GetRepository<TEntity>().Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            utwk.GetRepository<TEntity>().Update(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            utwk.GetRepository<TEntity>().Delete(entity);
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            utwk.GetRepository<TEntity>().Delete(where);
        }
        public virtual TEntity GetById(int id)
        {
            return utwk.GetRepository<TEntity>().GetById(id);
        }
        public virtual TEntity GetById(string id)
        {
            return utwk.GetRepository<TEntity>().GetById(id);
        }
        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null)
        {
            return utwk.GetRepository<TEntity>().GetMany(filter);
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return utwk.GetRepository<TEntity>().Get(where);
        }
        public virtual void Dispose()
        {
            utwk.Dispose();
        }
        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
