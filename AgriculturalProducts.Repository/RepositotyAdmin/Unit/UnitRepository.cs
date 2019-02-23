using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UnitRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
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
            Add(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            Update(unit);
        }
    }
}
