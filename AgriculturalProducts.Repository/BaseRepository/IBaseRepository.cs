using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        IEnumerable<TEntity> GetAllRecords();
        Task<TEntity> GetFirstOrDefault(Guid recordId);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
