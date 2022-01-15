using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public class DataBaseFactory : IDataBaseFactory
    {
        private DbContext _dbContext;

        public DbContext DataContext { get { return _dbContext; } }

        public DataBaseFactory()
        {
            _dbContext = new Context();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
