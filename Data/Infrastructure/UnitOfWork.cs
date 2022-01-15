namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        IDataBaseFactory dataBaseFactory;

        public UnitOfWork(IDataBaseFactory dataBaseFactory)
        {
            this.dataBaseFactory = dataBaseFactory;
        }

        public void Commit()
        {
            dataBaseFactory.DataContext.SaveChanges();
        }

        public void Dispose()
        {
            dataBaseFactory.Dispose();
        }

        public IRepositoryBase<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(dataBaseFactory);
        }
    }
}
