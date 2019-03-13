using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly IBaseRepository<TEntity> _reponsitory;
        private readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<TEntity> reponsitory)
        {
            _reponsitory = reponsitory;
            _unitOfWork = unitOfWork;
        }
        public void Add(TEntity entity)
        {
            _reponsitory.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _reponsitory.Delete(entity);
        }

        public IEnumerable<TEntity> GetAllRecords()
        {
            return _reponsitory.GetAllRecords();
        }

        public async Task<TEntity> GetFirstOrDefault(Guid id)
        {
            return await _reponsitory.GetFirstOrDefault(id);
        }

        public void Update(TEntity entity)
        {
            _reponsitory.Update(entity);
        }
    }
}
