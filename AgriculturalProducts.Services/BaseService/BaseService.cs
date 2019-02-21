﻿using AgriculturalProducts.Models;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<TEntity> _reponsitory;
        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<TEntity> reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }
        public void Add(TEntity entity)
        {
            _reponsitory.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(TEntity entity)
        {
            _reponsitory.Delete(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<TEntity> GetAllRecords()
        {
            return _reponsitory.GetAllRecords();
        }

        public async Task<TEntity> GetFirstOrDefault(Guid recordId)
        {
            return await _reponsitory.GetFirstOrDefault(recordId);
        }

        public void Update(TEntity entity)
        {
            _reponsitory.Update(entity);
            _unitOfWork.Commit();
        }
    }
}