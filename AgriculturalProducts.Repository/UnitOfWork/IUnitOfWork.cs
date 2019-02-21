using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
