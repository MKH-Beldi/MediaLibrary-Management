using System;

namespace Data.Infrastructure
{
    public interface IUnitOfWork: IDisposable
    {
        public void Commit();
        public IRepositoryBase<T> GetRepository<T>() where T: class;
    }
}
