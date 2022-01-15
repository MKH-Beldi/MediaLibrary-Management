using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        IDataBaseFactory dataBaseFactory;
        public DbSet<T> dbSet { get { return dataBaseFactory.DataContext.Set<T>(); } }

        public RepositoryBase(IDataBaseFactory dataBaseFactory)
        {
            this.dataBaseFactory = dataBaseFactory;
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (var obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where<T>(where).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> dbset = dbSet;
            if (where != null)
                dbset = dbset.Where(where);
            return dbset.AsEnumerable();
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataBaseFactory.DataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
