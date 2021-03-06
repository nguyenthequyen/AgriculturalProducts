﻿using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class UnitService : BaseService<Unit>, IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UnitService(IUnitOfWork unitOfWork, IUnitRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitRepository = reponsitory;
            _unitOfWork = unitOfWork;
        }

        public void DeleteUnit(List<Unit> unit)
        {
            foreach (var item in unit)
            {
                Delete(item);
            }
            _unitOfWork.Commit();
        }

        public async Task<Unit> FindUnitById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Unit> GetAllUnit()
        {
            return GetAllRecords();
        }

        public PageList<Unit> GetUnitPageList(PagingParams pagingParams)
        {
            if (string.IsNullOrEmpty(pagingParams.SearchString))
            {
                var unitdb = _unitRepository.GetAllRecords().OrderByDescending(x => x.ModifyDate);
                List<Unit> units = unitdb.ToList();
                var query = units.AsQueryable();
                return new PageList<Unit>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
            else
            {
                var unitdb = _unitRepository.GetAllRecords()
                    .Where(x => x.Name.Contains(pagingParams.SearchString))
                    .OrderByDescending(x => x.ModifyDate);
                List<Unit> units = unitdb.ToList();
                var query = units.AsQueryable();
                return new PageList<Unit>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
        }

        public void InsertUnit(List<Unit> unit)
        {
            foreach (var item in unit)
            {
                item.Id = Guid.NewGuid();
                item.ModifyDate = DateTime.Now;
                item.CreatedDate = DateTime.Now;
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public void UpdateUnit(List<Unit> unit)
        {
            foreach (var item in unit)
            {
                item.ModifyDate = DateTime.Now;
                Update(item);
            }
            _unitOfWork.Commit();
        }
    }
}
