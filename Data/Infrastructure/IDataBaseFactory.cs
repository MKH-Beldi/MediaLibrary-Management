using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Infrastructure
{
    public interface IDataBaseFactory: IDisposable
    {
        public DbContext DataContext { get; }
    }
}
