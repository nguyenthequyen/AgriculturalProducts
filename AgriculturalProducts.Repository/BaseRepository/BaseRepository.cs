using AgriculturalProducts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private ApplicationContext _applicationContext;
        public BaseRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public virtual void Add(TEntity entity)
        {
            _applicationContext.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _applicationContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAllRecords()
        {
            return _applicationContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetFirstOrDefault(Guid recordId)
        {
            return await _applicationContext.Set<TEntity>().FindAsync(recordId);
        }

        public virtual void Save()
        {
            _applicationContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _applicationContext.Set<TEntity>().Update(entity);
        }
    }
}
