using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IBlogsService<TEntity> : IService
     where TEntity : BaseEntity, new()
    {
        IEnumerable<TEntity> GetAllRecords();
        Task<TEntity> GetFirstOrDefault(Guid recordId);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
