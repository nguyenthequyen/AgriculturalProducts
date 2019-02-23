using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IUnitService : IBaseService<Unit>
    {
        void InsertUnit(Unit unit);
        void UpdateUnit(Unit unit);
        IEnumerable<Unit> GetAllUnit();
        void DeleteUnit(Unit unit);
        Task<Unit> FindUnitById(Guid id);

    }
}
