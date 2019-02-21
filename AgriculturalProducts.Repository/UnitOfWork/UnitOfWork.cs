using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationContext _applicationContext;
        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Commit()
        {
            _applicationContext.SaveChanges();
        }

        public void Dispose()
        {
            _applicationContext.Dispose();
        }
    }
}
