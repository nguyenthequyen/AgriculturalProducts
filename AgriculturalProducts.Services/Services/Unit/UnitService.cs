using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
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

        public void DeleteUnit(Unit unit)
        {
            Delete(unit);
        }

        public async Task<Unit> FindUnitById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Unit> GetAllUnit()
        {
            return GetAllRecords();
        }

        public void InsertUnit(Unit unit)
        {
            unit.Id = Guid.NewGuid();
            unit.ModifyDate = DateTime.Now;
            unit.CreatedDate = DateTime.Now;
            Add(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            unit.ModifyDate = DateTime.Now;
            Update(unit);
        }
    }
}
